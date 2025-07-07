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
        if (currentStage != null)
        {
            Debug.Log("StageManager: �����X�e�[�W�i�q�܂ށj���폜���܂� �� " + currentStage.name);

            // �q�����ׂč폜
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
            Debug.Log("StageManager: �V�����X�e�[�W�𐶐� �� " + stagePrefabs[index].name);
        }
        else
        {
            Debug.LogWarning("StageManager: �X�e�[�W�C���f�b�N�X���͈͊O�ł�");
        }
    }

    public void LoadNextStage()
    {
        int nextIndex = currentStageIndex + 1;
        if (nextIndex >= stagePrefabs.Length)
        {
            Debug.Log("���ׂẴX�e�[�W���N���A���܂����I");
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