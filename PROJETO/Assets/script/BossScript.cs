using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int vidaInicial = 40; // Variável para a vida inicial do chefe
    public int vida = 40;
    public float velocidade = 3f;
    private int direcao = 1; // 1 representa direção para a direita, -1 para a esquerda
    private bool virarSprite = false;
    private bool girando = false; // Variável para ativar a animação "girando"
    private Animator animator; // Referência para o componente Animator

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (vida <= 20 && vida >= 1) // Verifica se a vida do chefe está entre metade (20) e 1.
        {
            Movimento();
            GirarAnimacao();
        }
        if (vida <= 0)
        {
            girando = false;
            animator.SetBool("Girando", false); // Desativa a animação "Girando" quando a vida for zero
            // Você pode adicionar qualquer outra lógica que desejar aqui quando o chefe for derrotado.
        }
    }

    private void Movimento()
    {
        if (virarSprite)
        {
            // Inverter a escala X do sprite para mudar a direção
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            virarSprite = false;
        }

        // Movimentar o chefe na direção atual
        transform.Translate(Vector3.right * direcao * velocidade * Time.deltaTime);
    }

    private void GirarAnimacao()
    {
        // Ativar a animação "girando" definindo a variável de animação no Animator
        if (!girando)
        {
            girando = true;
            animator.SetBool("Girando", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parede"))
        {
            // Colisão com uma parede, inverter a direção
            direcao *= -1;
            virarSprite = true;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Colisão com o jogador, reduzir a vida do chefe
            vida--;
        }
    }
}
