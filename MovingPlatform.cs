using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    public Transform start;

    Vector3 next;

    void Start()
    {
        next = start.position;
    }

    void Update()
    {
        if(transform.position == pointA.position)
        {
            next = pointB.position;
        }
        if(transform.position == pointB.position)
        {
            next = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, next, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pointA.position, pointB.position);
    }


}
