using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    public override void Attack()
    {
        base.Attack();
    }

    public override void Update()
    {
        if(transform.position == waypoint1.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint2.position, speed * Time.deltaTime);
        }
        else if (transform.position == waypoint2.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint1.position, speed * Time.deltaTime);
        }
    }
}
