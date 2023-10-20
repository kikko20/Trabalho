using UnityEngine;

public class SeguirJogadorEDestruir : MonoBehaviour
{
    public string tagDoObjetoASeguir = "Player"; // A tag do objeto que o script deve seguir
    public float velocidade = 10.0f; // Velocidade do objeto

    private void Update()
    {
        GameObject objetoASeguir = GameObject.FindGameObjectWithTag(tagDoObjetoASeguir);

        if (objetoASeguir != null)
        {
            // Calcula a direção em que o objeto deve seguir o objeto com a tag especificada
            Vector3 direcao = (objetoASeguir.transform.position - transform.position).normalized;

            // Move o objeto na direção do objeto com a tag especificada com a velocidade especificada
            transform.Translate(direcao * velocidade * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagDoObjetoASeguir))
        {
            // Verifica se o objeto colidiu com um objeto que tenha a tag especificada
            // Se sim, destrua o objeto
            Destroy(gameObject);
        }
    }
}