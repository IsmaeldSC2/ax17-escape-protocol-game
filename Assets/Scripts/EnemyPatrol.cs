using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrulha")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float arrivalDistance = 0.05f;

    [Header("Detecção do Jogador")]
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRadius = 6f;
    [SerializeField] private LayerMask obstacleMask;

    [Header("Perseguição")]
    [SerializeField] private float chaseSpeed = 3f;

    private Transform currentTarget;
    private bool isChasing = false;

    private void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Os pontos de patrulha não foram configurados.", this);
            enabled = false;
            return;
        }

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
        }

        currentTarget = pointB;
    }

    private void FixedUpdate()
    {
        isChasing = CheckPlayerDetection();

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private bool CheckPlayerDetection()
    {
        if (player == null) return false;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > detectionRadius) return false;

        Vector2 direction = (player.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, obstacleMask);

        return hit.collider == null;
    }

    private void ChasePlayer()
    {
        MoveWithWallCheck(player.position, chaseSpeed);
    }

    private void Patrol()
    {
        MoveWithWallCheck(currentTarget.position, patrolSpeed);

        if (Vector2.Distance(transform.position, currentTarget.position) <= arrivalDistance)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }

    private void MoveWithWallCheck(Vector2 targetPosition, float speed)
{
    Vector2 currentPos = transform.position;
    Vector2 fullMove = Vector2.MoveTowards(currentPos, targetPosition, speed * Time.fixedDeltaTime) - currentPos;

    Vector2 moveX = new Vector2(fullMove.x, 0f);
    Vector2 moveY = new Vector2(0f, fullMove.y);

    Vector2 finalPosition = currentPos;

    if (moveX.magnitude > 0f && !Physics2D.Raycast(currentPos, moveX.normalized, moveX.magnitude, obstacleMask))
    {
        finalPosition.x += moveX.x;
    }

    if (moveY.magnitude > 0f && !Physics2D.Raycast(currentPos, moveY.normalized, moveY.magnitude, obstacleMask))
    {
        finalPosition.y += moveY.y;
    }

    transform.position = finalPosition;
}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = isChasing ? Color.red : Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}