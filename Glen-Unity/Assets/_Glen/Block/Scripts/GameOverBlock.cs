using UnityEngine;

public class GameOverBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponentInParent<PlayerManager>(); // Å© Ç±Ç±èCê≥ÅI
            if (player != null && player.IsInvincible())
            {
                Destroy(gameObject);
                Debug.Log("GameOverBlock Çñ≥ìGÉÇÅ[ÉhÇ≈îjâÛÅI");
            }
            else
            {
                TriggerGameOver();
            }
        }
    }

    public void TriggerGameOver()
    {
        Debug.Log("Game Over!");
        GameManager.Instance.ChangeState(new GameOverState());
    }
}