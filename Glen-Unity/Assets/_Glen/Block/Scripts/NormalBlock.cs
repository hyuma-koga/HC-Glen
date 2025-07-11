using UnityEngine;

public class NormalBlock : MonoBehaviour
{
    [SerializeField] private GameObject brokenPieceL;
    [SerializeField] private GameObject brokenPieceR;
    [SerializeField] private GameObject splashPrefab;
    [SerializeField] private float      explodeForce = 20f;
    [SerializeField] private float      torqueForce = 20f;
    [SerializeField] private float      pieceLifeTime = 3f;

    private GameOverBlock               linkedGameOverBlock;

    public void SetLinkedGameOverBlock(GameOverBlock gameOverBlock)
    {
        linkedGameOverBlock = gameOverBlock;
        gameOverBlock.SetLinkedNormalBlock(this);
    }

    public void CreateSplash(Vector3 position)
    {
        if (splashPrefab != null)
        {
            var splash = Instantiate(splashPrefab, position, Quaternion.Euler(90f, 0f, 0f), transform);
            Destroy(splash, 2f);
        }
    }

    public void Break()
    {
        if (brokenPieceL != null && brokenPieceR != null)
        {
            GameObject pieceL = Instantiate(brokenPieceL, transform.position, transform.rotation);
            GameObject pieceR = Instantiate(brokenPieceR, transform.position, transform.rotation);
            Rigidbody rbL = pieceL.GetComponent<Rigidbody>();
            Rigidbody rbR = pieceR.GetComponent<Rigidbody>();

            if (rbL != null)
            {
                rbL.isKinematic = false;
                rbL.useGravity = true;
                Vector3 forceDirL = (Vector3.left * 2f + Vector3.up * 3f).normalized; // �� ���ɕύX
                rbL.AddForce(forceDirL * explodeForce, ForceMode.VelocityChange);
                rbL.AddTorque(Random.onUnitSphere * torqueForce, ForceMode.Impulse);
                Destroy(pieceL, pieceLifeTime);
            }

            if (rbR != null)
            {
                rbR.isKinematic = false;
                rbR.useGravity = true;
                Vector3 forceDirR = (Vector3.right * 2f + Vector3.up * 3f).normalized; // �� �E�ɕύX
                rbR.AddForce(forceDirR * explodeForce, ForceMode.VelocityChange);
                rbR.AddTorque(Random.onUnitSphere * torqueForce, ForceMode.Impulse);
                Destroy(pieceR, pieceLifeTime);
            }

            if (linkedGameOverBlock != null)
            {
                Destroy(linkedGameOverBlock.gameObject);
            }

            ScoreManager.Instance.AddScore(1);
            gameObject.SetActive(false);
            Destroy(gameObject, pieceLifeTime);
        }

        gameObject.SetActive(false);
        Destroy(gameObject, pieceLifeTime);
    }
}