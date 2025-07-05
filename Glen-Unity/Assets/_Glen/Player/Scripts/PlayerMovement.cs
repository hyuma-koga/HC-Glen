using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform centerObject;
    [SerializeField] private float     speed_FallNormal = 5f;
    [SerializeField] private float     speed_FallBoost = 15f;
    [SerializeField] private float     radius = 2f;

    private Rigidbody rb;
    private bool      isBoosting = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //マウス左ボタンをホールドしている間ブースト
        if (Input.GetMouseButton(0))
        {
            isBoosting = true;
        }
        else
        {
            isBoosting = false;
        }

        //回転移動処理
        float mouseX = Input.mousePosition.x / Screen.width;
        float angle = mouseX * Mathf.PI * 2f;

        Vector3 centerPos = centerObject ? centerObject.position : Vector3.zero;

        float x = centerPos.x + radius * Mathf.Cos(angle);
        float z = centerPos.z + radius * Mathf.Sin(angle);

        Vector3 newPosition = new Vector3(x, transform.position.y, z);
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        float speed = isBoosting ? speed_FallBoost : speed_FallNormal;
        rb.linearVelocity = new Vector3(0, -speed, 0);
    }
}
