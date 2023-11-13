using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
    public int health = 600;

    public int balaPlayerDmg = 10;
    

    public void AplicarDano(int dano)
    {
        health -= balaPlayerDmg;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       Destroy(gameObject, 0.5f);
    }
}

    
