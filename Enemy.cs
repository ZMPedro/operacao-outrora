using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] protected int hp;
    [SerializeField] protected float speed;
    [SerializeField] protected Transform pointA, pointB;
    [SerializeField] protected GameObject shot;

    protected Vector3 target;
    protected Animator anim;
    protected SpriteRenderer sr;
    protected bool hit = false;
    protected bool dead = false;

    protected Player player;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init(); 
    }

    public virtual void Movement()
    {
        if (target == pointA.position)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            Debug.Log("PointA");
            target = pointB.position;
            anim.SetTrigger("idle");


        }
        else if (transform.position == pointB.position)
        {
            Debug.Log("PointB");
            target = pointA.position;
            anim.SetTrigger("idle");

        }

        if(hit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        //Debug.Log("Distance: " + distance);

        if (distance > 2.0f)
        {
            hit = false;
            anim.SetBool("combat", false);
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("combat") == true)
        {
            sr.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("combat") == true)
        {
            sr.flipX = true;
        }
    }

    public void Attack()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("combat") == false)
        {
            return;
        }

        if(dead == false)
        {
            Movement();
        }
    }
}
