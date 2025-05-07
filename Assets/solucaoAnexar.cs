using UnityEngine;
using Meta.XR.InteractionSDK;
using Oculus.Interaction.HandGrab;

public class ReparentOnGrab : MonoBehaviour
{
    private Transform originalParent;
    private Rigidbody rb;
    private HandGrabInteractable interactable;

    void Awake()
    {
        originalParent = transform.parent;
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<HandGrabInteractable>();

        // Eventos de pegar e soltar
        interactable.OnGrab += OnGrabbed;
        interactable.OnRelease += OnReleased;
    }

    private void OnDestroy()
    {
        // Sempre remova os callbacks para evitar memory leak
        interactable.OnGrab -= OnGrabbed;
        interactable.OnRelease -= OnReleased;
    }

    private void OnGrabbed(HandGrabInteractable interactable)
    {
        transform.parent = null;
        rb.isKinematic = true; // Evitar interfer�ncia da f�sica enquanto segurando
    }

    private void OnReleased(HandGrabInteractable interactable)
    {
        transform.parent = originalParent;
        rb.isKinematic = false; // Restaura f�sica
        rb.linearVelocity = Vector3.zero; // Zera a velocidade linear
        rb.angularVelocity = Vector3.zero; // Zera a velocidade angular
    }
}
