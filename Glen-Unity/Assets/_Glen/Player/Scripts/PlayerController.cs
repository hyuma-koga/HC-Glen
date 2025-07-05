using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement {  get; private set; }

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }
}
