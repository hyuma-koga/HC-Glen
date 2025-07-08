using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private float   invincibleDuration = 5f;
    [SerializeField] private float   pressThreshold = 5f;
    [SerializeField] private Image   invincibleMeterImage;
    [SerializeField] private Color   normalColor = Color.white;
    [SerializeField] private Color   invincibleColor = Color.red;

    public static PlayerManager      Instance { get; private set; }
    private Rigidbody                rb;
    private bool                     isInvincible = false;
    private float                    invincibleTimer = 0f;
    private float                    pressTimer = 0f;
    private bool                     canChargeInvincible = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();

        if (invincibleMeterImage != null)
        {
            invincibleMeterImage.color = normalColor;
            invincibleMeterImage.fillAmount = 0f;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (canChargeInvincible)
            {
                pressTimer += Time.unscaledDeltaTime;

                if (!isInvincible && pressTimer >= pressThreshold)
                {
                    ActivateInvincible();
                    canChargeInvincible = false;
                }

                float fill = Mathf.Clamp01(pressTimer / pressThreshold);

                if (invincibleMeterImage != null)
                {
                    invincibleMeterImage.fillAmount = fill;
                    invincibleMeterImage.fillClockwise = true;
                    invincibleMeterImage.color = normalColor;
                }
            }
        }
        else
        {
            pressTimer = 0f;

            if (!isInvincible)
            {
                canChargeInvincible = true;

                if (invincibleMeterImage != null)
                {
                    invincibleMeterImage.fillAmount = 0f;
                }
            }
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.unscaledDeltaTime;

            if (invincibleTimer <= 0f)
            {
                DeactivateInvincible();
            }

            float fill = Mathf.Clamp01(invincibleTimer / invincibleDuration);
            if (invincibleMeterImage != null)
            {
                invincibleMeterImage.fillAmount = fill;
                invincibleMeterImage.fillClockwise = false;
                invincibleMeterImage.color = invincibleColor;
            }
        }
    }

    private void ActivateInvincible()
    {
        isInvincible = true;
        invincibleTimer = invincibleDuration;

        if (invincibleMeterImage != null)
        {
            invincibleMeterImage.color = invincibleColor;
        }
    }

    private void DeactivateInvincible()
    {
        isInvincible = false;
        pressTimer = 0f;
        canChargeInvincible = true;

        if (invincibleMeterImage != null)
        {
            invincibleMeterImage.fillAmount = 0f;
            invincibleMeterImage.color = normalColor;
        }
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }

    public void ResetPlayerPosition()
    {
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep();
        }

        isInvincible = false;
        invincibleTimer = 0f;
        pressTimer = 0f;
        canChargeInvincible = true;

        if (invincibleMeterImage != null)
        {
            invincibleMeterImage.fillAmount = 0f;
            invincibleMeterImage.color = normalColor;
        }
    }
}