using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    [SerializeField] private float  bounceForce = 8f;
    [SerializeField] private string targetTag = "Block";

    public bool                     IsBouncing => isBouncing;
    private bool                    isBouncing = false;
    private Rigidbody               rb;
    private PlayerMovement          movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<PlayerMovement>();
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var gameOverBlock = collision.gameObject.GetComponentInParent<GameOverBlock>();
        
        if (movement != null && movement.IsBoosting && gameOverBlock != null)
        {
            gameOverBlock.TriggerGameOver();
            return;
        }

        if (!collision.gameObject.CompareTag(targetTag))
        {
            return;
        }

        var block = collision.gameObject.GetComponentInParent<NormalBlock>();

        if (movement != null && movement.IsBoosting && block != null)
        {
            block.Break();
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