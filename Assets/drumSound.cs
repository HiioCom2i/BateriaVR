using UnityEngine;

public class DrumSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip drumClip;
    public float minVolume = 0.1f;
    public float maxVolume = 1.0f;
    public float maxVelocity = 2.0f; // Ajuste conforme necessário

    private DrumVisualPulse visualPulse;

    void Start()
    {
        visualPulse = GetComponent<DrumVisualPulse>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Baqueta"))
        {
            Rigidbody rb = collision.rigidbody;
            float volume = maxVolume;

            if (rb != null)
            {
                float velocity = rb.linearVelocity.magnitude;
                Debug.Log("Velocidade da baqueta: " + velocity);

                float normalized = Mathf.Clamp01(velocity / maxVelocity);
                volume = Mathf.Lerp(minVolume, maxVolume, normalized);
            }

            audioSource.PlayOneShot(drumClip, volume);

            if (visualPulse != null)
            {
                visualPulse.Pulse();
            }
        }
    }
}
