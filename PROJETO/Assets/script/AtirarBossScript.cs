using UnityEngine;

public class AtirarBossScript : MonoBehaviour
{
    public GameObject laiserPrefab;
    public Transform laiserSpawnPoint;
    public float tempoEntreTiros = 2.0f; // Tempo em segundos entre cada tiro
    private float tempoUltimoTiro = 0.0f;

    public int vidaInicial = 10; // Defina a vida inicial do boss aqui
    private BossScript bossScript; // Referência ao script principal do boss

    void Start()
    {
        bossScript = GetComponent<BossScript>(); // Obter referência ao script principal do boss
    }

    void Update()
    {
        // Verificar se o boss tem 50% ou menos de vida
        if (bossScript.vida <= vidaInicial / 2)
        {
            AtirarLaiser();
        }
    }

    void AtirarLaiser()
    {
        if (Time.time - tempoUltimoTiro >= tempoEntreTiros)
        {
            // Instanciar o Prefab do projétil do "laiser" no ponto de spawn
            Instantiate(laiserPrefab, laiserSpawnPoint.position, Quaternion.identity);
            tempoUltimoTiro = Time.time;
        }
    }
}