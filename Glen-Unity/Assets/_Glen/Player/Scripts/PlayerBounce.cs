using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    [SerializeField] private float  bounceForce = 8f;
    [SerializeField] private string targetTag = "Block";
    [SerializeField] private float  extraFallForce = 30f;

    public bool                     IsBouncing => isBouncing;
    private bool                    isBouncing = false;
    private Rigidbody               rb;
    private PlayerMovement          movement;
    private PlayerManager           playerManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<PlayerMovement>();
        playerManager = GetComponent<PlayerManager>();
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var gameOverBlock = collision.gameObject.GetComponentInParent<GameOverBlock>();

        if (gameOverBlock != null)
        {
            var player = GetComponent<PlayerManager>();

            if (playerManager != null && playerManager.IsInvincible())
            {
                gameOverBlock.DestroyWithScore();
                return;
            }

            if (movement != null && movement.IsBoosting)
            {
                gameOverBlock.TriggerGameOver();
                return;
            }
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
            if (block != null)
            {
                block.CreateSplash(collision.contacts[0].point);
            }
        }
    }

    private void Update()
    {
        if (rb.linearVelocity.y < 0f)
        {
            rb.AddForce(Vector3.down * extraFallForce, ForceMode.Acceleration);
        }

        if (isBouncing && rb.linearVelocity.y <= 0f)
        {
            isBouncing = false;
        }
    }
}