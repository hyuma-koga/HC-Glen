using UnityEngine;

public class PlayState : IGameState
{
    public void Enter()
    {
        Debug.Log("Enter Play State");
        UIManager.Instance.ShowGameUI();
        Time.timeScale = 1;
    }

    public void Update()
    {
    }

    public void Exit()
    {
        Debug.Log("Exit Play State");
        UIManager.Instance.HideGameUI();
    }
}