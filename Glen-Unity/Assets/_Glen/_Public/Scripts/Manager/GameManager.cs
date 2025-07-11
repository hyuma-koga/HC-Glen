using UnityEngine;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public IGameState         CurrentState => currentState;
    private IGameState        currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(new TitleState());
    }

    private void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(IGameState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    public void GameOver()
    {
        ChangeState(new GameOverState());
    }

    public void GameClear()
    {
        ChangeState(new ClearState());
    }
}