using UnityEngine;
using System.Collections;

public class DrumVisualPulse : MonoBehaviour
{
    public Color pulseColor = Color.yellow;
    public float pulseDuration = 0.15f;
    public float pulseScale = 1.1f;
    public float pulseSpeed = 10f; // quanto maior, mais r�pido

    private Renderer drumRenderer;
    private Color originalColor;
    private Vector3 originalScale;
    private bool isPulsing = false;

    void Start()
    {
        drumRenderer = GetComponent<Renderer>();
        if (drumRenderer != null)
        {
            originalColor = drumRenderer.material.color;
        }

        originalScale = transform.localScale;
    }

    public void Pulse()
    {
        if (!isPulsing)
        {
            StartCoroutine(PulseEffectSmooth());
        }
    }

    private IEnumerator PulseEffectSmooth()
    {
        isPulsing = true;

        drumRenderer.material.color = pulseColor;

        // Crescer suavemente
        originalScale = transform.localScale;
        Vector3 targetScale = originalScale * pulseScale;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * pulseSpeed;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        // Voltar suavemente
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * pulseSpeed;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            yield return null;
        }

        drumRenderer.material.color = originalColor;
        transform.localScale = originalScale;

        isPulsing = false;
    }
}
