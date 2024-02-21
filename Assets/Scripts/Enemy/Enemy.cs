using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    public int health;
    [SerializeField]
    public int speed;
    [SerializeField]
    public int gems;

    [SerializeField]
    protected Transform waypoint1;
    [SerializeField]
    protected Transform waypoint2;

    public virtual void Attack()
    {
        
    }

    public abstract void Update();
}
