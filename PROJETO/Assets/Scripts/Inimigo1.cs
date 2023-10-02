using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Inimigo1 : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rig;

    private Animator anime;

    public Transform leftcol;
    public Transform rightcol;

    private bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
        colliding = Physics.Linecast(rightcol.position, leftcol.position);
        
        if (colliding)
        {
            speed = -speed;
        }
    }
}


