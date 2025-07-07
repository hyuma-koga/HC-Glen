using UnityEngine;
using UnityEngine.XR;

public class ClearState : IGameState
{
    public void Enter()
    {
        Debug.Log("Enter Clear State");
        UIManager.Instance.ShowClearUI();
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
            else
            {
                Debug.LogWarning("PlayerManager.Instance ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ‚Å‚µ‚½");
            }

            GameManager.Instance.ChangeState(new TitleState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Clear State");
        UIManager.Instance.HideClearUI();
    }
}