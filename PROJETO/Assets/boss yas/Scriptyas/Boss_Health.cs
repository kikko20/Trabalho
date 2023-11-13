using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    
    public int vidaAtual;
    public int vidaTotal = 600;

    public int balaPlayerDmg = 30;
    
    
    
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private Animator animator;
    
    [SerializeField] private AudioSource DeathSong;
    
    private bool isDead = false;
    BossYas boss;
    
    void Start()
    {
        vidaAtual = vidaTotal;
        barraDeVida.AlterarBarraDeVida(vidaAtual, vidaTotal);
        
        animator = GetComponent<Animator>();
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
        isDead = true;
        animator.SetTrigger("Die");
        DeathSong.Play();

        Destroy(gameObject, 1f);
    }
}

    
