using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject clearUI;
    [SerializeField] private GameObject progressUI;
    [SerializeField] private Button@@ startButton;
    [SerializeField] private TMP_Text @gameScoreText;
    [SerializeField] private TMP_Text   gameOverScoreText;
    [SerializeField] private TMP_Text   gameOverBestScoreText;
    [SerializeField] private TMP_Text   currentStageText;
    [SerializeField] private TMP_Text   nextStageText;

    public static UIManager Instance { get; private set; }

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

    private void Update()
    {
        if (gameScoreText != null)
        {
            gameScoreText.text = "" + ScoreManager.Instance.CurrentScore;
        }
    }

    public void UpdateGameOverScore()
    {
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "" + ScoreManager.Instance.CurrentScore;
        }

        if (gameOverBestScoreText != null)
        {
            gameOverBestScoreText.text = "" + ScoreManager.Instance.BestScore;
        }
    }

    public void OnStartButtonClicked()
    {
        GameManager.Instance.ChangeState(new PlayState());
    }

    public void UpdateStageTexts(int current, int next)
    {
        if (currentStageText != null)
        {
            currentStageText.text = "" + current.ToString();
        }

        if (nextStageText != null)
        {
            nextStageText.text = "" + next.ToString();
        }
    }

    public void ShowTitleUI() => titleUI.SetActive(true);
    public void HideTitleUI() => titleUI.SetActive(false);

    public void ShowGameUI() => gameUI.SetActive(true);
    public void HideGameUI() => gameUI.SetActive(false);

    public void ShowGameOverUI() => gameOverUI.SetActive(true);
    public void HideGameOverUI() => gameOverUI.SetActive(false);

    public void ShowClearUI() => clearUI.SetActive(true);
    public void HideClearUI() => clearUI.SetActive(false);

    public void ShowProgressUI() => progressUI.SetActive(true);
    public void HideProgressUI() => progressUI.SetActive(false);
}