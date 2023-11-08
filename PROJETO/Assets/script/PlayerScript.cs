using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int vidaInicial = 40; // Vida inicial do jogador
    public int vida; // Vida atual do jogador

    void Start()
    {
        vida = vidaInicial;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("Bala"))
        {
            ReduzirVida(1);
        }
    }

    void ReduzirVida(int quantidade)
    {
        vida -= quantidade;

        if (vida <= 0)
        {
            // O jogador está sem vida, resete a fase
            ResetarFase();
        }
    }

    void ResetarFase()
    {
        // Carrega a cena atual novamente
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}