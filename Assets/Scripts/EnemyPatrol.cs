using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float arrivalDistance = 0.05f;

    private Transform currentTarget;

    private void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Os pontos de patrulha não foram configurados.", this);
            enabled = false;
            return;
        }

        currentTarget = pointB;
    }

    private void FixedUpdate()
    {
        Vector2 nextPosition = Vector2.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.fixedDeltaTime
        );

        transform.position = nextPosition;

        if (Vector2.Distance(transform.position, currentTarget.position) <= arrivalDistance)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }
}