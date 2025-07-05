using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform centerObject;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float boostForce = 20f;

    public bool IsBoosting => isBoosting;
    private bool isBoosting = false;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    private void Update()
    {
        float mouseX = Input.mousePosition.x / Screen.width;
        float angle = mouseX * Mathf.PI * 2f;

        Vector3 centerPos = centerObject ? centerObject.position : Vector3.zero;

        float x = centerPos.x + radius * Mathf.Cos(angle);
        float z = centerPos.z + radius * Mathf.Sin(angle);

        Vector3 newPosition = new Vector3(x, transform.position.y, z);
        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        isBoosting = Input.GetMouseButton(0);

        if (isBoosting)
        {
            BoostFall();
        }
    }

    private void BoostFall()
    {
        rb.AddForce(Vector3.down * boostForce, ForceMode.Acceleration);
    }
}