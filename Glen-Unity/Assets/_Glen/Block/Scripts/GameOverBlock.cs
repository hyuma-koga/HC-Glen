using UnityEngine;

public class GameOverBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponentInParent<PlayerManager>(); // �� �����C���I
            if (player != null && player.IsInvincible())
            {
                Destroy(gameObject);
                Debug.Log("GameOverBlock �𖳓G���[�h�Ŕj��I");
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