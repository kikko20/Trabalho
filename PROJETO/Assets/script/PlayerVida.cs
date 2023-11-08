using UnityEngine;
using TMPro;
public class PlayerVida : MonoBehaviour
{
    public int vidaMaxima = 40;
    public int vidaAtual;

    public TextMeshProUGUI textoVida; // Certifique-se de vincular o objeto TextMeshPro no Inspector.

    private void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarTextoVida();
    }

    private void AtualizarTextoVida()
    {
        if (textoVida != null)
        {
            textoVida.text = "Vida do player: " + vidaAtual;
        }
    }

    public void ReceberDano(int quantidade)
    {
        vidaAtual -= quantidade;
        if (vidaAtual < 0)
        {
            vidaAtual = 0;
        }

        AtualizarTextoVida();

        if (vidaAtual <= 0)
        {
            // O jogador está sem vida, você pode adicionar lógica para resetar a fase aqui.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("Player"))
        {
            // Colisão com um objeto de tag "Boss" ou "Player", subtrai 1 da vida do jogador ou chefe
            ReceberDano(1);
        }
    }

}