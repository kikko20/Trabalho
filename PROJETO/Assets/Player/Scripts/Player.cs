using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;

    public Animator animator;

    private Vector3 facingRight;
    private Vector3 facingLeft;

    public bool taNoChao;
    public Transform detectarChao;
    public LayerMask oQueEhChao;

    public int pulosExtras = 1;
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("taCorrendo", true);
        }
        else
        {
            animator.SetBool("taCorrendo", false);
        }

            taNoChao = Physics2D.OverlapCircle(detectarChao.position, 0.2f, oQueEhChao);

        if (Input.GetButtonDown("Jump") && taNoChao == true)
        {
            rb.velocity = Vector2.up * 12;
            animator.SetBool("taPulando", true);
        }
        if (Input.GetButtonDown("Jump") && taNoChao == false && pulosExtras > 0)
        {
            rb.velocity = Vector2.up * 12;
            pulosExtras--;
            animator.SetBool("puloDuplo", true);
        }

        if (taNoChao && rb.velocity.y == 0)
        {
            pulosExtras = 1;
            animator.SetBool("taPulando", false);
            animator.SetBool("puloDuplo", false);
        }
        
        direction = Input.GetAxis("Horizontal");

        if (direction > 0)
        {
            transform.localScale = facingRight;
        }

        if (direction < 0)
        {
            transform.localScale = facingLeft;
        }
        
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }
}
