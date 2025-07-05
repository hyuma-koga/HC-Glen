using UnityEngine;

public class NormalBlock : MonoBehaviour
{
    [SerializeField] private GameObject brokenPieceL;
    [SerializeField] private GameObject brokenPieceR;
    [SerializeField] private float explodeForce = 20f;
    [SerializeField] private float torqueForce = 20f;
    [SerializeField] private float pieceLifeTime = 3f;

    public void Break()
    {
        Debug.Log("Break");

        // 両方 null でないか確認
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

        // 破片の寿命に合わせて最終的にDestroy
        Destroy(gameObject, pieceLifeTime);
    }
}