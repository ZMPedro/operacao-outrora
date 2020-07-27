using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{


    private Rigidbody2D rb;
    [SerializeField] private float jumpforce;
    private bool resetjump = false;
    private bool grounded = false;
    [SerializeField] private float movespeed;
    private PlayerAnimation pa;
    private SpriteRenderer sr;
    

    public int health { get; set; }

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pa = GetComponent<PlayerAnimation>();
        sr = GetComponentInChildren<SpriteRenderer>();
        

        jumpforce = 14f;
        movespeed = 8f;
    }
    
    void Update()
    {
        Movement();
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

        if(move > 0)
        {
            sr.flipX = false;
        }
        if(move < 0)
        {
            sr.flipX = true;
        }
       
    
        if(Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            StartCoroutine(resetJumpRoutine());
            pa.Jump(true);
        }

        //
        //tentar aplicar GetKeyUp com mudança na gravidade para mudar intensidade do pulo
        //

        rb.velocity = new Vector2(move * movespeed, rb.velocity.y);

        pa.Move(move);
    }

    bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down * 1.4f, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.4f, 1 << 9);
        if(hit.collider != null)
        {
            if(resetjump == false)
            {
                pa.Jump(false);
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
