using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public int damage = 10;
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Boss"))
            {
                
                col.GetComponent<Boss_Health>().TakeDamage(damage);
                
                Destroy(gameObject);
            }
    }
}
