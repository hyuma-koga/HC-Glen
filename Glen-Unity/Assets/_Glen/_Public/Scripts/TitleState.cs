using UnityEngine;
using UnityEngine.Playables;

public class TitleState : IGameState
{
    public void Enter()
    {
        if (StageManager.Instance.GetCurrentStage() != null)
        {
            Debug.Log("TitleState: 前回ステージを強制削除");
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
        Debug.Log("Exit Title State");
        UIManager.Instance.HideTitleUI();
    }
}