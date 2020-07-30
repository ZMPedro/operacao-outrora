using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{

    [SerializeField] protected Transform pointA, pointB;
    

    protected Vector3 target;
    protected SpriteRenderer sr;
    protected bool hit = false;

    protected Player player;

    private void Start()
    {
        Init();
        facingRight = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Movement()
    {

        if (hit == false)
        {
            if (target == pointA.position && facingRight)
            {
                Flip();
            }
            else if (target == pointB.position && !facingRight)
            {
                Flip();
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

            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
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
        GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.identity);

        //if (sr.flipX)
        //{
        //    shot.transform.Translate
        //}
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle") && anim.GetBool("combat") == false)
        {
            return;
        }

        if(dead == false)
        {
            Movement();
        }
    }
}
