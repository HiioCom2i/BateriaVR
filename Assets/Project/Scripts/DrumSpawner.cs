using UnityEngine;

public class DrumSpawner : MonoBehaviour
{
    public GameObject drumPrefab;   // Arraste aqui o prefab do seu tambor
    public Transform spawnPoint;     // Onde o tambor vai aparecer

    public void SpawnDrum()
    {
        if(drumPrefab != null && spawnPoint != null)
        {
            Instantiate(drumPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Prefab ou Spawn Point não configurado!");
        }
    }
}
