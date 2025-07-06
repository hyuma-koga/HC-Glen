using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject clearUI;

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

    public void ShowTitleUI() => titleUI.SetActive(true);
    public void HideTitleUI() => titleUI.SetActive(false);

    public void ShowGameUI() => gameUI.SetActive(true);
    public void HideGameUI() => gameUI.SetActive(false);

    public void ShowGameOverUI() => gameOverUI.SetActive(true);
    public void HideGameOverUI() => gameOverUI.SetActive(false);

    public void ShowClearUI() => clearUI.SetActive(true);
    public void HideClearUI() => clearUI.SetActive(false);
}