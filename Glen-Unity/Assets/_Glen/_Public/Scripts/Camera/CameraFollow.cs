using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Player
    public Transform center;        // Tower の中心
    public float distance = 6f;     // タワーからの距離
    public float height = 2f;       // 高さオフセット
    public float fixedAngleX = 30f; // 固定 X 回転角

    private void LateUpdate()
    {
        if (target == null || center == null)
        {
            return;
        }

        // Tower から Player への水平方向ベクトル
        Vector3 offsetDir = new Vector3(target.position.x - center.position.x, 0f, target.position.z - center.position.z).normalized;

        // Tower 基準でカメラ位置を決定（完全固定距離）
        Vector3 desiredPosition = center.position + offsetDir * distance;
        desiredPosition.y = target.position.y + height;

        // 即座に配置
        transform.position = desiredPosition;

        // Y 回転だけ追従
        Vector3 lookDir = target.position - transform.position;
        float angleY = Quaternion.LookRotation(lookDir).eulerAngles.y;
        transform.rotation = Quaternion.Euler(fixedAngleX, angleY, 0f);
    }
}