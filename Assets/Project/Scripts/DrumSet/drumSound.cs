using UnityEngine;

public class DrumSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip drumClip;
    public float minVolume = 0.1f;
    public float maxVolume = 1.0f;
    public float maxVelocity = 3.0f;

    private DrumVisualPulse visualPulse;

    private void Start()
    {
        visualPulse = GetComponentInParent<DrumVisualPulse>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Baqueta"))
        {
            StickVelocity stickVel = other.GetComponent<StickVelocity>();
            float velocity = stickVel != null ? stickVel.currentVelocity : 0f;

            float volume = Mathf.Clamp01(velocity / maxVelocity);
            volume = Mathf.Lerp(minVolume, maxVolume, volume);

            audioSource.PlayOneShot(drumClip, volume);

            if (visualPulse != null)
                visualPulse.Pulse();
        }
    }

}
