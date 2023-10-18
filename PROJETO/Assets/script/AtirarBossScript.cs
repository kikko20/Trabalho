using UnityEngine;

public class AtirarBossScript : MonoBehaviour
{
    public GameObject laiserPrefab;
    public Transform pontoDeSpawnLaiser; // Objeto vazio que representa o ponto de spawn
    public float tempoEntreTiros = 2.0f; // Tempo em segundos entre cada tiro
    private float tempoUltimoTiro = 0.0f;
    private Animator animator; // Referência ao componente Animator
    private BossScript bossScript; // Referência ao script principal do boss
    public int vidaInicial = 10; // Variável para a vida inicial do boss

    void Start()
    {
        animator = GetComponent<Animator>();
        bossScript = GetComponent<BossScript>();
    }

    void Update()
    {
        // Verifique se o boss tem 50% ou menos de vida para ativar a animação "atirando"
        if (bossScript.vida <= vidaInicial / 2)
        {
            AtirarLaiser();
            animator.SetBool("Atirando", true); // Ativar a animação "atirando"
        }
        else
        {
            animator.SetBool("Atirando", false); // Desativar a animação "atirando"
        }
    }

    void AtirarLaiser()
    {
        if (Time.time - tempoUltimoTiro >= tempoEntreTiros)
        {
            // Instanciar o Prefab do projétil do "laiser" no ponto de spawn (objeto vazio)
            Instantiate(laiserPrefab, pontoDeSpawnLaiser.position, Quaternion.identity);
            tempoUltimoTiro = Time.time;
        }
    }
}