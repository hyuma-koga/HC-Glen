using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject clearUI;
    [SerializeField] private Button startButton;

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
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonClicked);
        }
    }

    public void OnStartButtonClicked()
    {
        GameManager.Instance.ChangeState(new PlayState());
    }

    public void ShowTitleUI() => titleUI.SetActive(true);
    public void HideTitleUI() => titleUI.SetActive(false);

    public void ShowGameUI() => gameUI.SetActive(true);
    public void HideGameUI() => gameUI.SetActive(false);

    public void ShowGameOverUI() => gameOverUI.SetActive(true);
    public void HideGameOverUI() => gameOverUI.SetActive(false);

    public void ShowClearUI() => clearUI.SetActive(true);
    public void HideClearUI() => clearUI.SetActive(false);
}