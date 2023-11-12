using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossYas : MonoBehaviour
{
    public GameObject Player;
    public Transform player;
    public bool isFlipped = false;
    private bool atk;
    
    [SerializeField] public AudioSource walkSound;
    [SerializeField] public AudioSource ataqSom;
    
    void Start()
    {
        if (Player != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player.GetComponent<Collider2D>());
        }
    }



    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
            
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

  
    
}
