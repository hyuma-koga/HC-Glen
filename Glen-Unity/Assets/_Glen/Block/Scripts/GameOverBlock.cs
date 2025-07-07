using UnityEngine;

public class GameOverBlock : MonoBehaviour
{
    [SerializeField] private GameObject brokenPieceL;
    [SerializeField] private GameObject brokenPieceR;
    [SerializeField] private float      explodeForce = 20f;
    [SerializeField] private float      torqueForce = 20f;
    [SerializeField] private float      pieceLifeTime = 3f;

    private NormalBlock linkedNormalBlock;

    public void SetLinkedNormalBlock(NormalBlock normalBlock)
    {
        linkedNormalBlock = normalBlock;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponentInParent<PlayerManager>();

            if (player != null && player.IsInvincible())
            {
                Break();
            }
            else
            {
                TriggerGameOver();
            }
        }
    }

    public void TriggerGameOver()
    {
        GameManager.Instance.ChangeState(new GameOverState());
    }

    public void DestroyWithScore()
    {
        ScoreManager.Instance.AddScore(1);
        Break();
    }

    private void Break()
    {
        if (linkedNormalBlock != null)
        {
            linkedNormalBlock.gameObject.SetActive(false);
            Destroy(linkedNormalBlock.gameObject, pieceLifeTime);
        }

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
                Vector3 forceDirL = (Vector3.left * 2f + Vector3.up * 3f).normalized;
                rbL.AddForce(forceDirL * explodeForce, ForceMode.VelocityChange);
                rbL.AddTorque(Random.onUnitSphere * torqueForce, ForceMode.Impulse);
                Destroy(pieceL, pieceLifeTime);
            }

            if (rbR != null)
            {
                rbR.isKinematic = false;
                rbR.useGravity = true;
                Vector3 forceDirR = (Vector3.right * 2f + Vector3.up * 3f).normalized;
                rbR.AddForce(forceDirR * explodeForce, ForceMode.VelocityChange);
                rbR.AddTorque(Random.onUnitSphere * torqueForce, ForceMode.Impulse);
                Destroy(pieceR, pieceLifeTime);
            }
        }

        gameObject.SetActive(false);
        Destroy(gameObject, pieceLifeTime);
    }
}