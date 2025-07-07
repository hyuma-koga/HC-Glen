using UnityEngine;

public class PlayState : IGameState
{
    public void Enter()
    {
        UIManager.Instance.ShowGameUI();
        UIManager.Instance.ShowProgressUI();
        Time.timeScale = 1;
    }

    public void Update()
    {
    }

    public void Exit()
    {
        UIManager.Instance.HideGameUI();
    }
}