using UnityEngine;

public class BlockFadeOut : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1.5f;

    private Renderer blockRenderer;
    private Material material;
    private Color originalColor;
    private float elapsed = 0f;

    private void Start()
    {
        // �q�I�u�W�F�N�g���܂߂� Renderer ��T��
        blockRenderer = GetComponent<Renderer>();
        if (blockRenderer == null)
        {
            blockRenderer = GetComponentInChildren<Renderer>();
        }

        if (blockRenderer != null)
        {
            material = blockRenderer.material;
            originalColor = material.color;
        }
        else
        {
            Debug.LogError("Renderer ��������܂���BBlockFadeOut ��t����I�u�W�F�N�g���m�F���Ă��������B");
            enabled = false; // �������~
        }
    }

    private void Update()
    {
        if (material == null) return;

        elapsed += Time.deltaTime;

        float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
        material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

        if (alpha <= 0f)
        {
            Destroy(gameObject);
        }
    }
}