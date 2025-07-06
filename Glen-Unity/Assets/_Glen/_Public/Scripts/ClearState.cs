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
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.ChangeState(new TitleState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Clear State");
        UIManager.Instance.HideClearUI();
    }
}