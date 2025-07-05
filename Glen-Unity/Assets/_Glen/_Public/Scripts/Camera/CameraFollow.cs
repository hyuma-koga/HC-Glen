using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Player
    public Transform center;        // Tower �̒��S
    public float distance = 6f;     // �^���[����̋���
    public float height = 2f;       // �����I�t�Z�b�g
    public float fixedAngleX = 30f; // �Œ� X ��]�p

    private void LateUpdate()
    {
        if (target == null || center == null)
        {
            return;
        }

        // Tower ���� Player �ւ̐��������x�N�g��
        Vector3 offsetDir = new Vector3(target.position.x - center.position.x, 0f, target.position.z - center.position.z).normalized;

        // Tower ��ŃJ�����ʒu������i���S�Œ苗���j
        Vector3 desiredPosition = center.position + offsetDir * distance;
        desiredPosition.y = target.position.y + height;

        // �����ɔz�u
        transform.position = desiredPosition;

        // Y ��]�����Ǐ]
        Vector3 lookDir = target.position - transform.position;
        float angleY = Quaternion.LookRotation(lookDir).eulerAngles.y;
        transform.rotation = Quaternion.Euler(fixedAngleX, angleY, 0f);
    }
}