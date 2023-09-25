using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Inimigo1 : MonoBehaviour
{
    public int Speed;

    private Rigidbody2D rig;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        // Inicia o movimento do inimigo em uma nova thread
        InvokeRepeating("Move", 0f, 5f);
    }

    private void Move()
    {
        if (movingRight)
        {
            rig.velocity = new Vector2(Speed, rig.velocity.y);
        }
        else
        {
            rig.velocity = new Vector2(-Speed, rig.velocity.y);
        }

        movingRight = !movingRight;
    }
}


