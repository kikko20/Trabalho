using UnityEngine;

public class MovimentoObjeto : MonoBehaviour
{
    public float velocidade = 5.0f; // Velocidade de movimento no eixo X
    private float tempoDeVida = 4.0f; // Tempo em segundos antes de destruir o objeto

    void Start()
    {
        // Destrói o objeto após o tempo de vida
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        // Movimenta-se apenas para a direita no eixo X
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parede") || collision.gameObject.CompareTag("Player"))
        {
            // Colisão com "Parede" ou "Player", destruir o objeto
            Destroy(gameObject);
        }
    }
}