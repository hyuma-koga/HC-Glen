using UnityEngine;
using UnityEngine.Playables;

public class TitleState : IGameState
{
    public void Enter()
    {
        Debug.Log("Enter Title State");
        UIManager.Instance.ShowTitleUI();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.ChangeState(new PlayState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Title State");
        UIManager.Instance.HideTitleUI();
    }
}