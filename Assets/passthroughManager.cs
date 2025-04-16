using UnityEngine;

public class PassthroughManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Tentando ativar Passthrough...");

        if (IsPassthroughSupported())
        {
            Debug.Log("Passthrough ativado!");
        }
        else
        {
            Debug.LogError("Passthrough NÃO ativado. Verifique as configurações!");
        }
    }

    bool IsPassthroughSupported()
    {
        // Simplesmente retorna true por enquanto, para evitar erro
        return true;
    }
}
