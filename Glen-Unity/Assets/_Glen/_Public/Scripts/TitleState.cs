using UnityEngine;
using UnityEngine.Playables;

public class TitleState : IGameState
{
    public void Enter()
    {
        int currentStage = StageManager.Instance.GetCurrentStageIndex() + 1;
        int nextStage = Mathf.Min(currentStage + 1, StageManager.Instance.GetMaxStageCount());

        if (StageManager.Instance.GetCurrentStage() != null)
        {
            Object.Destroy(StageManager.Instance.GetCurrentStage());
        }

        StageManager.Instance.LoadStage(StageManager.Instance.GetCurrentStageIndex());
        UIManager.Instance.UpdateStageTexts(currentStage, nextStage);
        UIManager.Instance.ShowTitleUI();
        UIManager.Instance.ShowProgressUI();
    }

    public void Update()
    {
        
    }

    public void Exit()
    {
        UIManager.Instance.HideTitleUI();
    }
}