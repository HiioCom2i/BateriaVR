using UnityEngine;

public class DrumVisualFeedback : MonoBehaviour
{
    public Color pulseColor = Color.yellow;
    public float pulseDuration = 0.1f;

    private Renderer drumRenderer;
    private Color originalColor;
    private bool isPulsing = false;

    void Start()
    {
        drumRenderer = GetComponent<Renderer>();
        if (drumRenderer != null)
        {
            originalColor = drumRenderer.material.color;
        }
    }

    public void Pulse()
    {
        if (!isPulsing)
        {
            StartCoroutine(PulseEffect());
        }
    }

    private System.Collections.IEnumerator PulseEffect()
    {
        isPulsing = true;
        drumRenderer.material.color = pulseColor;
        yield return new WaitForSeconds(pulseDuration);
        drumRenderer.material.color = originalColor;
        isPulsing = false;
    }
}
