using UnityEngine;
using UnityEngine.Playables;

public class TitleState : IGameState
{
    public void Enter()
    {
        if (StageManager.Instance.GetCurrentStage() != null)
        {
            Object.Destroy(StageManager.Instance.GetCurrentStage());
        }

        StageManager.Instance.LoadStage(StageManager.Instance.GetCurrentStageIndex());
        UIManager.Instance.ShowTitleUI();
    }

    public void Update()
    {
        
    }

    public void Exit()
    {
        UIManager.Instance.HideTitleUI();
    }
}