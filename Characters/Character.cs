using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
	[SerializeField] protected int HP;
    [SerializeField] protected float moveSpeed;
	[SerializeField] protected GameObject shotPrefab;
	
	protected Animator anim;
	protected bool dead = false;
	protected bool facingRight;
	
	protected void Init()
	{
		anim = GetComponentInChildren<Animator>();
	}
	
	protected void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
