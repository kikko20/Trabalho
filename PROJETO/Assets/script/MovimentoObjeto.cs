using UnityEngine;

public class MovimentoObjeto : MonoBehaviour
{
    public float velocidade = 5.0f; // Velocidade de movimento no eixo X
    private Transform jogador; // Referência ao jogador
    private float tempoDeVida = 4.0f; // Tempo em segundos antes de destruir o objeto

    void Start()
    {
        // Encontra o jogador com a tag "Player"
        jogador = GameObject.FindWithTag("Player").transform;

        // Destrói o objeto após o tempo de vida
        Destroy(gameObject, tempoDeVida);
    }

    void Update()
    {
        if (jogador != null)
        {
            // Calcula a direção em que o jogador está em relação ao objeto
            Vector3 direcao = (jogador.position - transform.position);

            // Mantém o movimento apenas no eixo X
            direcao.y = 0;

            // Normaliza a direção para manter a mesma velocidade
            direcao.Normalize();

            // Move o objeto no eixo X com base na direção e na velocidade
            transform.Translate(direcao * velocidade * Time.deltaTime);

            // Verifica se o objeto encontrou o eixo Y do jogador
            if (Mathf.Abs(transform.position.y - jogador.position.y) < 0.1f)
            {
                // Destruir o objeto
                Destroy(gameObject);
            }
        }
        else
        {
            // Movimenta-se apenas em linha reta no eixo X
            transform.Translate(Vector3.right * velocidade * Time.deltaTime);
        }
    }
}