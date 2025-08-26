using UnityEngine;

public class DrumButtonTouch : MonoBehaviour
{
    public DrumSpawner drumSpawner;
    private bool isPressed = false; // trava para evitar múltiplos spawns

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            isPressed = true; // trava
            if (drumSpawner != null)
                drumSpawner.SpawnDrum();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPressed = false; // libera para o próximo toque
    }
}
