using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] stagePrefabs;

    private GameObject currentStage;
    private int currentStageIndex = 0;

    public static StageManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void LoadStage(int index)
    {
        // 既存ステージがあれば削除
        if (currentStage != null)
        {
            Destroy(currentStage);
        }

        // 範囲チェック
        if (index >= 0 && index < stagePrefabs.Length)
        {
            currentStage = Instantiate(stagePrefabs[index]);
            currentStageIndex = index;
        }
        else
        {
            Debug.LogWarning("ステージインデックスが範囲外です");
        }
    }

    public void LoadNextStage()
    {
        int nextIndex = currentStageIndex + 1;
        if (nextIndex >= stagePrefabs.Length)
        {
            Debug.Log("すべてのステージをクリアしました！");
            // 必要ならここで「最終クリア演出」や「タイトルに戻す」など
            GameManager.Instance.ChangeState(new ClearState());
            return;
        }

        LoadStage(nextIndex);
    }

    public void ReloadCurrentStage()
    {
        LoadStage(currentStageIndex);
    }

    public int GetCurrentStageIndex()
    {
        return currentStageIndex;
    }

    public GameObject GetCurrentStage()
    {
        return currentStage;
    }
}