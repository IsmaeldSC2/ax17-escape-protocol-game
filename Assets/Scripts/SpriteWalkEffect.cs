using UnityEngine;

public class SpriteWalkEffect : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform spriteTransform;
    [SerializeField] private float bobSpeed = 10f;
    [SerializeField] private float bobAmount = 0.05f;
    [SerializeField] private float tiltAmount = 8f;
    [SerializeField] private float movementThreshold = 0.05f;

    private float bobTimer = 0f;
    private Vector3 baseScale;

    private void Start()
    {
        if (rb == null) rb = GetComponentInParent<Rigidbody2D>();
        if (spriteTransform == null) spriteTransform = transform;
        baseScale = spriteTransform.localScale;
    }

    private void Update()
    {
        bool isMoving = rb != null && rb.linearVelocity.magnitude > movementThreshold;

        if (isMoving)
        {
            bobTimer += Time.deltaTime * bobSpeed;
            float bob = Mathf.Sin(bobTimer) * bobAmount;
            spriteTransform.localScale = new Vector3(baseScale.x, baseScale.y + bob, baseScale.z);

            float tilt = Mathf.Sin(bobTimer) * tiltAmount;
            spriteTransform.localRotation = Quaternion.Euler(0f, 0f, tilt);
        }
        else
        {
            bobTimer = 0f;
            spriteTransform.localScale = baseScale;
            spriteTransform.localRotation = Quaternion.identity;
        }
    }
}