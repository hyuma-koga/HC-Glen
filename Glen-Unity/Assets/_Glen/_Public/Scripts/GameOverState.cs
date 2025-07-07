using UnityEngine;

public class GameOverState : IGameState
{
    public void Enter()
    {
        Debug.Log("Enter GameOver State");
        UIManager.Instance.ShowGameOverUI();
        Time.timeScale = 0f; // © ƒQ[ƒ€‚ğ’â~
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f; // ŠÔ‚ğ–ß‚·
            GameManager.Instance.ChangeState(new TitleState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exit GameOver State");
        UIManager.Instance.HideGameOverUI();
    }
}