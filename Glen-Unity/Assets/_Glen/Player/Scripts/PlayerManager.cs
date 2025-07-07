using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField] private Vector3 initialPosition;

    private Rigidbody rb;

    private bool isInvincible = false;
    private float invincibleDuration = 5f;
    private float invincibleTimer = 0f;

    private float pressTimer = 0f;
    private float pressThreshold = 5f;
    private bool canChargeInvincible = true; // �� �V�t���O

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ���G��������
        if (Input.GetMouseButton(0))
        {
            if (canChargeInvincible)
            {
                pressTimer += Time.unscaledDeltaTime;

                if (!isInvincible && pressTimer >= pressThreshold)
                {
                    ActivateInvincible();
                    canChargeInvincible = false; // �� ������͈�x�����ɂ���
                }
            }
        }
        else
        {
            pressTimer = 0f;

            // �{�^���𗣂�����ă`���[�W�ł���悤�ɂ���
            if (!isInvincible)
            {
                canChargeInvincible = true;
            }
        }

        // ���G���ԊǗ�
        if (isInvincible)
        {
            invincibleTimer -= Time.unscaledDeltaTime;
            if (invincibleTimer <= 0f)
            {
                DeactivateInvincible();
            }
        }
    }

    private void ActivateInvincible()
    {
        Debug.Log("���G���[�h�����I");
        isInvincible = true;
        invincibleTimer = invincibleDuration;
    }

    private void DeactivateInvincible()
    {
        Debug.Log("���G���[�h�I��");
        isInvincible = false;
        pressTimer = 0f;
        canChargeInvincible = true; // �� ���G�I����̓`���[�W�\�ɖ߂�
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

        // ��ԃ��Z�b�g
        isInvincible = false;
        invincibleTimer = 0f;
        pressTimer = 0f;
        canChargeInvincible = true;
    }
}