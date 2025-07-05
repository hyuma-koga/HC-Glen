using UnityEngine;

public class GameOverState : IGameState
{
    public void Enter()
    {
        Debug.Log("Enter GameOver State");
        UIManager.Instance.ShowGameOverUI();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.ChangeState(new TitleState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exit GameOver State");
        UIManager.Instance.HideGameOverUI();
    }
}
