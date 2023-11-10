using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject balaProjetil;
    public Transform arma;
    private bool tiro;
    public float forcaDoTiro;
    private bool flipX;


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

        tiro = Input.GetButtonDown("Fire1");
        Atirar();

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

        if ( flipX == true && direction > 0)
        {
            Flip();
            //transform.localScale = facingRight;
        }

        if (flipX == false && direction < 0)
        {
            Flip();
            //transform.localScale = facingLeft;
        }
        
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    private void Atirar()
    {
        if (tiro == true)
        {
            GameObject temp = Instantiate(balaProjetil);
            temp.transform.position = arma.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro, 0);
            Destroy(temp.gameObject, 3f);
        }
    }

    private void Flip()
    {
        flipX = !flipX;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        forcaDoTiro *= -1;
    }
    
}
