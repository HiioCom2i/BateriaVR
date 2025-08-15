using UnityEngine;

public class CameraMirror : MonoBehaviour
{
    public Renderer mirrorRenderer; // Arraste o Renderer do plano aqui
    private WebCamTexture webCamTexture;

    void Start()
    {
        // Cria a textura da webcam
        webCamTexture = new WebCamTexture();

        // Aplica a textura no material do plano
        mirrorRenderer.material.mainTexture = webCamTexture;

        // Começa a captura da câmera
        webCamTexture.Play();

        // Espelha horizontalmente para parecer um espelho
        mirrorRenderer.material.mainTextureScale = new Vector2(-1, 1);
    }
}
