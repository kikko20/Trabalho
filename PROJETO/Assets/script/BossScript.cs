using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int vida = 10;
    public float velocidade = 3f;
    private int direcao = 1; // 1 representa direção para a direita, -1 para a esquerda

    private bool virarSprite = false;

    void Update()
    {
        if (vida > 5)
        {
            Movimento();
        }
    }

    void Movimento()
    {
        if (virarSprite)
        {
            // Inverter a escala X do sprite para mudar a direção
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            virarSprite = false;
        }

        // Movimentar o boss na direção atual
        transform.Translate(Vector3.right * direcao * velocidade * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parede"))
        {
            // Colisão com uma parede, inverter a direção
            direcao *= -1;
            virarSprite = true;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Colisão com o jogador, reduzir a vida do boss
            vida--;
            
        }
    }
}