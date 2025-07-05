using UnityEngine;

public class PlayerSquash : MonoBehaviour
{
    [SerializeField] private float squashAmountY = 0.6f;
    [SerializeField] private float squashAmountX = 1.2f;
    [SerializeField] private float squashSpeed = 10f;
    [SerializeField] private float returnSpeed = 5f;

    private Vector3 originalScale;
    private Vector3 squashScale;
    private Vector3 squashVelocity;
    private Vector3 returnVelocity;
    private bool isSquashing = false;
    private bool isReturning = false;

    private void Start()
    {
        originalScale = transform.localScale;
        squashScale = new Vector3(
            originalScale.x * squashAmountX,
            originalScale.y * squashAmountY,
            originalScale.z * squashAmountX
        );
    }

    public void TriggerSquash()
    {
        isSquashing = true;
        isReturning = false;
    }

    private void Update()
    {
        if (isSquashing)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, squashScale, ref squashVelocity, 1f / squashSpeed);

            if (Vector3.Distance(transform.localScale, squashScale) < 0.01f)
            {
                transform.localScale = squashScale; // ÅI“I‚ÉŠ®‘Sˆê’v
                isSquashing = false;
                isReturning = true;
            }
        }
        else if (isReturning)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, originalScale, ref returnVelocity, 1f / returnSpeed);

            if (Vector3.Distance(transform.localScale, originalScale) < 0.01f)
            {
                transform.localScale = originalScale; // Š®‘Sˆê’v
                isReturning = false;
            }
        }
    }
}