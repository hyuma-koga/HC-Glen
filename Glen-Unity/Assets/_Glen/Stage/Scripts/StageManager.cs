using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] stagePrefabs;

    public static StageManager            Instance { get; private set; }
    private GameObject                    currentStage;
    private int                           currentStageIndex = 0;

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

    public void LoadStage(int index)
    {
        if (currentStage != null)
        {
            foreach (Transform child in currentStage.transform)
            {
                Destroy(child.gameObject);
            }

            Destroy(currentStage);
        }

        if (index >= 0 && index < stagePrefabs.Length)
        {
            currentStage = Instantiate(stagePrefabs[index]);
            currentStageIndex = index;
        }
    }

    public void LoadNextStage()
    {
        int nextIndex = currentStageIndex + 1;

        if (nextIndex >= stagePrefabs.Length)
        {
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