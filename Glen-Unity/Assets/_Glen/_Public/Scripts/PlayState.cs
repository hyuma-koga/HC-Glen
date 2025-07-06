using UnityEngine;

public class PlayState : IGameState
{
    public void Enter()
    {
        Debug.Log("Enter Play State");
        UIManager.Instance.ShowGameUI();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameManager.Instance.ChangeState(new GameOverState());
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Instance.ChangeState(new ClearState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Play State");
        UIManager.Instance.HideGameUI();
    }
}