using System.Collections;
using UnityEngine;

public class TamborAnimacao : MonoBehaviour
{
    // Defina o tempo do "bloop"
    public float tempoAnimacao = 0.2f;
    public Vector3 escalaAumentada = new Vector3(1.2f, 1.2f, 1.2f);  // Aumento da escala
    private Vector3 escalaOriginal;

    void Start()
    {
        // Guarda a escala original do cilindro
        escalaOriginal = transform.localScale;
    }

    void OnCollisionEnter(Collision colisao)
    {
        // Verifica se o tambor foi atingido por algo (por exemplo, uma palheta)
        if (colisao.gameObject.CompareTag("Palheta"))  // Certifique-se de que a palheta tenha a tag "Palheta"
        {
            Debug.Log("Tambor atingido");
            StartCoroutine(AnimarBloop());
        }
    }

    IEnumerator AnimarBloop()
    {
        // Aumenta a escala do cilindro
        transform.localScale = escalaAumentada;

        // Aguarda um pouco
        yield return new WaitForSeconds(tempoAnimacao);

        // Volta para a escala original
        transform.localScale = escalaOriginal;
    }
}