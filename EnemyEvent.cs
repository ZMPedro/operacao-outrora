using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvent : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = transform.parent.GetComponent<Enemy>();
    }

    public void Fire()
    {
        Debug.Log("Enemy fire");
        enemy.Attack();
    }
}
