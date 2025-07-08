using UnityEngine;

public class BlockSpawer_0002 : MonoBehaviour
{
    [SerializeField] private GameObject prefab_NormalBlock_0002;
    [SerializeField] private GameObject prefab_GameOverBlock_0002;
    [SerializeField] private Transform  centerObject;
    [SerializeField] private int        spawnCount = 20;
    [SerializeField] private float      startY = 5f;
    [SerializeField] private float      intervalY = 5f;
    [SerializeField] private float      angleStep = 20f;

    private float currentAngle = 0f;

    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float yPos = startY - i * intervalY;

            Vector3 posNormal = new Vector3(centerObject.position.x, yPos, centerObject.position.z);
            Quaternion rotNormal = Quaternion.Euler(0f, currentAngle, 0f);

            var normalObj = Instantiate(prefab_NormalBlock_0002, posNormal, rotNormal, this.transform);

            Vector3 posGameOver = new Vector3(centerObject.position.x, yPos, centerObject.position.z);
            Quaternion rotGameOver = Quaternion.Euler(0f, currentAngle, 0f);

            var gameOverObj = Instantiate(prefab_GameOverBlock_0002, posGameOver, rotGameOver, this.transform);
            var normalBlock = normalObj.GetComponent<NormalBlock>();
            var gameOverBlock = gameOverObj.GetComponent<GameOverBlock>();

            if (normalBlock != null && gameOverBlock != null)
            {
                normalBlock.SetLinkedGameOverBlock(gameOverBlock);
            }

            currentAngle -= angleStep;
        }
    }
}