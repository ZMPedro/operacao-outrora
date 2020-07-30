using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{
	[SerializeField] protected int HP;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float gunCooldown;

    [SerializeField] protected GameObject shotPrefab;
    [SerializeField] protected Transform firePoint;

    protected Animator anim;

	protected bool dead = false;
	protected bool facingRight;
    protected float nextFireTime = 0;
	
	protected void Init()
	{
		anim = GetComponentInChildren<Animator>();
	}
	
	protected void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Damage()
    {
        //if (dead == true)
        //{
        //    return;
        //}
        HP--;
        if (HP < 1)
        {
            dead = true;
            //sanim.SetTrigger("death");

        }
    }

    protected abstract void Shoot();

}
