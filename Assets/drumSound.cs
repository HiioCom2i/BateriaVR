using UnityEngine;

public class DrumSound : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entrou em contato com o tambor: " + other.name);

        if (other.CompareTag("Baqueta"))
        {
            Debug.Log("A baqueta bateu no tambor!");
            audioSource.Play();
        }
    }
}