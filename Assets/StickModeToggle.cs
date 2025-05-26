using UnityEngine;

public class StickModeToggle : MonoBehaviour
{
    public GameObject leftStick;
    public GameObject rightStick;

    public Transform leftHandAttachPoint;
    public Transform rightHandAttachPoint;

    private bool sticksAreAttached = false;

    public void ToggleStickMode()
    {
        sticksAreAttached = !sticksAreAttached;

        if (sticksAreAttached)
        {
            AttachStick(leftStick, leftHandAttachPoint);
            AttachStick(rightStick, rightHandAttachPoint);
        }
        else
        {
            DetachStick(leftStick);
            DetachStick(rightStick);
        }
    }

    private void AttachStick(GameObject stick, Transform handTransform)
    {
        stick.transform.SetParent(handTransform);
        stick.transform.localPosition = Vector3.zero; // ajuste se quiser
        stick.transform.localRotation = Quaternion.identity;

        Rigidbody rb = stick.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void DetachStick(GameObject stick)
    {
        stick.transform.SetParent(null);

        Rigidbody rb = stick.GetComponent<Rigidbody>();
        rb.isKinematic = true;  // mantém cinemática mesmo solta
    }

}
