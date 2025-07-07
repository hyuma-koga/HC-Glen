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
    private bool canChargeInvincible = true; // ← 新フラグ

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
        // 無敵発動条件
        if (Input.GetMouseButton(0))
        {
            if (canChargeInvincible)
            {
                pressTimer += Time.unscaledDeltaTime;

                if (!isInvincible && pressTimer >= pressThreshold)
                {
                    ActivateInvincible();
                    canChargeInvincible = false; // ← 発動後は一度無効にする
                }
            }
        }
        else
        {
            pressTimer = 0f;

            // ボタンを離したら再チャージできるようにする
            if (!isInvincible)
            {
                canChargeInvincible = true;
            }
        }

        // 無敵時間管理
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
        Debug.Log("無敵モード発動！");
        isInvincible = true;
        invincibleTimer = invincibleDuration;
    }

    private void DeactivateInvincible()
    {
        Debug.Log("無敵モード終了");
        isInvincible = false;
        pressTimer = 0f;
        canChargeInvincible = true; // ← 無敵終了後はチャージ可能に戻す
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

        // 状態リセット
        isInvincible = false;
        invincibleTimer = 0f;
        pressTimer = 0f;
        canChargeInvincible = true;
    }
}