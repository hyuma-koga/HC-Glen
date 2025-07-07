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
        // �����X�e�[�W������΍폜
        if (currentStage != null)
        {
            Destroy(currentStage);
        }

        // �͈̓`�F�b�N
        if (index >= 0 && index < stagePrefabs.Length)
        {
            currentStage = Instantiate(stagePrefabs[index]);
            currentStageIndex = index;
        }
        else
        {
            Debug.LogWarning("�X�e�[�W�C���f�b�N�X���͈͊O�ł�");
        }
    }

    public void LoadNextStage()
    {
        int nextIndex = currentStageIndex + 1;
        if (nextIndex >= stagePrefabs.Length)
        {
            Debug.Log("���ׂẴX�e�[�W���N���A���܂����I");
            // �K�v�Ȃ炱���Łu�ŏI�N���A���o�v��u�^�C�g���ɖ߂��v�Ȃ�
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