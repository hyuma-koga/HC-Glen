using UnityEngine;
using UnityEngine.XR;

public class ClearState : IGameState
{
    public void Enter()
    {
        UIManager.Instance.ShowClearUI();
        UIManager.Instance.ShowProgressUI();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StageManager.Instance.LoadNextStage();

            if (PlayerManager.Instance != null)
            {
                PlayerManager.Instance.ResetPlayerPosition();
            }

            GameManager.Instance.ChangeState(new TitleState());
        }
    }

    public void Exit()
    {
        UIManager.Instance.HideClearUI();
    }
}