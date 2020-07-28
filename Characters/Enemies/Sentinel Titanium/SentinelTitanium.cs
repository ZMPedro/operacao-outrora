using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentinelTitanium : Enemy, IDamageable
{
    public int health { get; set; }
    

    public override void Init()
    {
        base.Init();
        health = base.hp;
    }

    

    public override void Update()
    {
        
    }

    public void Damage()
    {
        if (dead == true)
        {
            return;
        }
        health--;
        if(health < 1)
        {
            dead = true;
            anim.SetTrigger("death");
            
        }
    }

    

    public override void Movement()
    {
        
    }
}
