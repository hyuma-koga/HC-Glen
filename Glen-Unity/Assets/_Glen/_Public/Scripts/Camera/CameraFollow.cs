using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Player
    public Transform center;        // CenterMarker
    public float distance = 6f;
    public float height = 2f;
    public float fixedAngleX = 30f;

    private void LateUpdate()
    {
        // center Ç™ null Ç»ÇÁçƒíTçı
        if (center == null && StageManager.Instance != null)
        {
            GameObject stageObj = StageManager.Instance.GetCurrentStage();
            if (stageObj != null)
            {
                Transform foundCenter = stageObj.transform.Find("CenterMarker");
                if (foundCenter != null)
                {
                    center = foundCenter;
                    Debug.Log("CameraFollow: CenterMarker ÇçƒéÊìæÇµÇ‹ÇµÇΩÅI");
                }
            }
        }

        if (target == null || center == null)
        {
            return;
        }

        Vector3 offsetDir = new Vector3(target.position.x - center.position.x, 0f, target.position.z - center.position.z).normalized;
        Vector3 horizontalBasePos = center.position + offsetDir * distance;
        Vector3 desiredPosition = new Vector3(horizontalBasePos.x, target.position.y + height, horizontalBasePos.z);

        transform.position = desiredPosition;

        Vector3 lookDir = target.position - transform.position;
        float angleY = Quaternion.LookRotation(lookDir).eulerAngles.y;
        transform.rotation = Quaternion.Euler(fixedAngleX, angleY, 0f);
    }
}