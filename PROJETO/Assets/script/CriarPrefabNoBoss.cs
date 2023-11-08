using UnityEngine;

public class CriarPrefabNoBoss : MonoBehaviour
{
    public Transform localDeCriacao; // Referência ao local onde o prefab será criado
    public GameObject prefabACriar; // Referência ao prefab que será criado
    public BossScript boss; // Referência ao script do boss
    public float tempoDeDisparo = 0.2f; // Intervalo entre disparos em segundos
    private float tempoUltimoDisparo = 0.0f; // Tempo do último disparo

    private void Update()
    {
        if (boss.vida <= boss.vidaInicial / 2 && Time.time - tempoUltimoDisparo >= tempoDeDisparo)
        {
            Instantiate(prefabACriar, localDeCriacao.position, Quaternion.identity);
            tempoUltimoDisparo = Time.time;
        }
    }
}