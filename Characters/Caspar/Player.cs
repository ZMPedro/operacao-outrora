using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IDamageable
{


    private Rigidbody2D rb;
    

    private bool resetjump = false;
    private bool grounded = false;
    

    [SerializeField] private float jumpForce;
    
    
    
    

    public int health { get; set; }

    
    void Start()
    {
        Init();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        jumpForce = 14f;
        moveSpeed = 8f;
    }
    
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.L))
        {
            anim.SetTrigger("shoot");
        }
    }

    //Não está sendo chamado
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger called");
        if (other.gameObject.CompareTag("Platform") && !IsGrounded())
        {
            grounded = true;
            transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        grounded = IsGrounded();

        if (move > 0 && !facingRight)
        {
            Flip();
        }

        else if (move < 0 && facingRight)
        {
            Flip();
        }


        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(resetJumpRoutine());
            anim.SetBool("jump", true);
        }

        //
        //tentar aplicar GetKeyUp com mudança na gravidade para mudar intensidade do pulo
        //

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        anim.SetFloat("speed", Mathf.Abs(move));
    }

    

    bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down * 1.4f, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.4f, 1 << 9);
        if(hit.collider != null)
        {
            if(resetjump == false)
            {
                anim.SetBool("jump", false);
                return true;
            }
            
        }
        return false;
    }


   IEnumerator resetJumpRoutine()
    {
        resetjump = true;
        yield return new WaitForSeconds(0.1f);
        resetjump = false;
    }

    public void Damage()
    {
        Debug.Log("Player::Damage()");
    }
    

}
