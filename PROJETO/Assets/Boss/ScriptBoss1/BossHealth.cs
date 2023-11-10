using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 500;

    public GameObject deathEffect;

    public bool isInvulnerable = false;

    public int balaPlayerDmg = 20;

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        } 
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("bala"))
        {
            TakeDamage(balaPlayerDmg);
        }
    }
}
