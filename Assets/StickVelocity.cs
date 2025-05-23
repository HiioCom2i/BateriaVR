using UnityEngine;

public class StickVelocity : MonoBehaviour
{
    private Vector3 lastPosition;
    public float currentVelocity { get; private set; }

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        currentVelocity = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform.position;
    }
}
