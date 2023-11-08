using UnityEngine;
using TMPro;

public class ColisaoPlayerBoss : MonoBehaviour
{
    public TextMeshProUGUI vidaBossText; // Referência ao objeto de texto para exibir a vida do boss
    public int vidaMaximaBoss = 40; // Vida máxima do boss
    private int vidaAtualBoss; // Vida atual do boss

    private void Start()
    {
        vidaAtualBoss = vidaMaximaBoss; // Inicializa a vida do boss
        AtualizarVidaBossNaTela();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            DiminuirVidaDoBoss(1); // Reduz a vida do boss em 1
            AtualizarVidaBossNaTela();
        }
    }

    private void DiminuirVidaDoBoss(int quantidade)
    {
        vidaAtualBoss -= quantidade;
        vidaAtualBoss = Mathf.Clamp(vidaAtualBoss, 0, vidaMaximaBoss); // Garante que a vida do boss não seja negativa ou maior do que a vida máxima
    }

    private void AtualizarVidaBossNaTela()
    {
        vidaBossText.text = "HP: " + vidaAtualBoss.ToString();
    }
}


