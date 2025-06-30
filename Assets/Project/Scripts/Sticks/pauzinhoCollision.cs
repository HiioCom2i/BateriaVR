using UnityEngine;

public class BaquetaCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tambor"))
        {
            Debug.Log("Baqueta bateu no tambor!");
        }
    }
}

