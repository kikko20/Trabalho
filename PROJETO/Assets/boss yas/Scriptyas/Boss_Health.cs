using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public int vidaAtual;
    public int vidaTotal = 600;

    public int balaPlayerDmg = 10;
    
    [SerializeField] private BarraDeVida barraDeVida;
    
    void Start()
    {
        vidaAtual = vidaTotal;
        
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
    }


    public void AplicarDano(int dano)
    {
        vidaAtual -= dano;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);

        if (vidaAtual <= 0)
        {
            Die();
        }
    }
    
    

    void Die()
    {
        Destroy(gameObject, 0.5f);
    }
}

    
