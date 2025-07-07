using UnityEngine;
using UnityEngine.UI;

public class StageProgress : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Slider    progressSlider;

    private float startY = 99f;
    private float clearY = 0f;

    private void Update()
    {
        if (playerTransform == null || progressSlider == null)
        {
            return;
        }

        float currentY = Mathf.Clamp(playerTransform.position.y, clearY, startY);
        float progress = 1f - ((currentY - clearY) / (startY - clearY));

        progressSlider.value = progress;
    }
}