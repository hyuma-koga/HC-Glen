using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement { get; private set; }
    public PlayerBounce   bounce   { get; private set; }
    public PlayerSquash   squash   { get; private set; }

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        bounce = GetComponent<PlayerBounce>();
        squash = GetComponent<PlayerSquash>();
    }
}