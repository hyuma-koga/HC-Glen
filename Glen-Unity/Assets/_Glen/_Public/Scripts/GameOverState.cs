using UnityEngine;

public class GameOverState : IGameState
{
    public void Enter()
    {
        Debug.Log("Enter GameOver State");
        UIManager.Instance.ShowGameOverUI();
        Time.timeScale = 0f; // �� �Q�[�����~
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f; // ���Ԃ�߂�
            GameManager.Instance.ChangeState(new TitleState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exit GameOver State");
        UIManager.Instance.HideGameOverUI();
    }
}