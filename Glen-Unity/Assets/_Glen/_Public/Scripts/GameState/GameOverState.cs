using UnityEngine;

public class GameOverState : IGameState
{
    public void Enter()
    {
        Debug.Log("Enter GameOver State");
        UIManager.Instance.ShowGameOverUI();
        UIManager.Instance.ShowProgressUI();
        UIManager.Instance.UpdateGameOverScore();
        Time.timeScale = 0f;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerManager.Instance != null)
            {
                PlayerManager.Instance.ResetPlayerPosition();
            }

            GameManager.Instance.ChangeState(new TitleState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exit GameOver State");
        UIManager.Instance.HideGameOverUI();
        ScoreManager.Instance.ResetScore();
    }
}