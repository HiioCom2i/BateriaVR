using UnityEngine;

public class GrabDebug : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entrou no trigger: " + other.name);

        if (other.CompareTag("LeftHand") || other.CompareTag("RightHand"))
        {
            Debug.Log("Mão detectada pelo tambor!");
        }
    }
}
