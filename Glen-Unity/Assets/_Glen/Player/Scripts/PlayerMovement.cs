using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform      centerObject;
    [SerializeField] private ParticleSystem invincibleFlameEffect;
    [SerializeField] private float          radius = 2f;
    [SerializeField] private float          moveSpeed = 5f;
    [SerializeField] private float          boostForce = 20f;
    [SerializeField] private float          invincibleForceMultiplier = 0.5f;

    [SerializeField] private Vector3        normalScale = Vector3.one;
    [SerializeField] private Vector3        fallingScale = new Vector3(1f, 1.5f, 1f);
    [SerializeField] private float          scaleLerpSpeed = 5f;

    public bool                             IsBoosting => isBoosting;
    private bool                            isBoosting = false;
    private Rigidbody                       rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

        if (centerObject == null)
        {
            centerObject = transform.Find("CenterMarker");
        }

        if (invincibleFlameEffect != null)
        {
            invincibleFlameEffect.Stop();
        }
    }

    private void Update()
    {
        if (!(GameManager.Instance.CurrentState is PlayState))
        {
            return;
        }

        float mouseX = Input.mousePosition.x / Screen.width;
        float angle = mouseX * Mathf.PI * 2f;

        Vector3 centerPos = centerObject ? centerObject.position : Vector3.zero;

        float x = centerPos.x + radius * Mathf.Cos(angle);
        float z = centerPos.z + radius * Mathf.Sin(angle);

        Vector3 newPosition = new Vector3(x, transform.position.y, z);
        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
        var player = GetComponent<PlayerManager>();

        if (player != null && player.IsInvincible())
        {
            if (invincibleFlameEffect != null && !invincibleFlameEffect.isPlaying)
            {
                invincibleFlameEffect.Play();
            }
        }
        else
        {
            if (invincibleFlameEffect != null && invincibleFlameEffect.isPlaying)
            {
                invincibleFlameEffect.Stop();
            }
        }

        if (rb.linearVelocity.y < -0.1f || isBoosting || (player != null && player.IsInvincible()))
        {
            transform.localScale = Vector3.Lerp(transform.localScale, fallingScale, Time.deltaTime * scaleLerpSpeed);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, normalScale, Time.deltaTime * scaleLerpSpeed);
        }
    }

    private void FixedUpdate()
    {
        if (!(GameManager.Instance.CurrentState is PlayState))
        {
            return;
        }

        isBoosting = Input.GetMouseButton(0);

        if (isBoosting)
        {
            BoostFall();
        }
    }

    private void BoostFall()
    {
        var player = GetComponent<PlayerManager>();

        if (player != null && player.IsInvincible())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -boostForce * invincibleForceMultiplier, rb.linearVelocity.z);
        }
        else
        {
            rb.AddForce(Vector3.down * boostForce, ForceMode.Acceleration);
        }
    }
}