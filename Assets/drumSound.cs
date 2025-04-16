using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drumSound : MonoBehaviour
{
    private AudioSource audioSource;
    void Start(){
        
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Baqueta")){
            
            Debug.Log("Baqueta bateu no tambor!");

            Rigidbody rb = other.GetComponent<Rigidbody>();


            if (rb != null && audioSource != null){
                
                float velocidade = rb.linearVelocity.magnitude;

                float volume = Mathf.Clamp01(1- Mathf.Exp(-velocidade * 5f));
                
                audioSource.volume = volume;
                audioSource.Play();

                Debug.Log($"Velocidade: {velocidade}, Volume: {volume}");
            }
        }
    }
}
