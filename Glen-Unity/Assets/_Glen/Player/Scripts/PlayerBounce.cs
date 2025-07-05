using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    [SerializeField] private float bounceForce = 8f;
    [SerializeField] private string targetTag = "NormalBlock";

    public bool IsBouncing => isBouncing;
    private bool isBouncing = false;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(targetTag))
        {
            return;
        }

        if (rb.linearVelocity.y <= 0.1f)
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            isBouncing = true;

            var squash = GetComponent<PlayerSquash>();
            if (squash != null)
            {
                squash.TriggerSquash();
            }
        }
    }

    private void Update()
    {
        if (isBouncing && rb.linearVelocity.y <= 0f)
        {
            isBouncing = false;
        }
    }
}