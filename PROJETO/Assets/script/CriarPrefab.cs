using UnityEngine;

public class CriarPrefab : MonoBehaviour
{
    public Transform localDeCriacao; // Referência ao local onde o objeto será criado
    public GameObject prefabACriar; // Referência ao prefab que será criado
    public BossScript boss; // Referência ao script do boss

    private bool prefabCriado = false; // Variável para controlar se o prefab foi criado

    private void Update()
    {
        if (!prefabCriado && boss.vida <= boss.vidaInicial / 2)
        {
            Instantiate(prefabACriar, localDeCriacao.position, Quaternion.identity);
            prefabCriado = true;
        }
    }
}