using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroLaser : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * velocidade; }
    
}