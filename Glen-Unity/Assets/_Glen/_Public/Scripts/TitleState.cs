using UnityEngine;
using UnityEngine.Playables;

public class TitleState : IGameState
{
    public void Enter()
    {
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