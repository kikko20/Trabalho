using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Boss"))
            {

                col.GetComponent<Boss_Health>().AplicarDano(30);
                
                Destroy(gameObject);
            }
    }
}
