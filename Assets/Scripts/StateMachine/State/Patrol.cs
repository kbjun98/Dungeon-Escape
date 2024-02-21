using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LightWeightFSM
{

    public class Patrol : State
    {
        [SerializeField]
        private Transform waypoint1;
        [SerializeField]
        private Transform waypoint2;
        private Transform currentWaypoint;
        [SerializeField]
        private float patrolSpeed=5.0f;
        private void Start()
        {
            currentWaypoint = waypoint1;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            GetComponentInChildren<Animator>().SetTrigger("Walk");
        }

        private void LateUpdate()
        {
            if (transform.position == waypoint1.position)
            {
                currentWaypoint= waypoint2;
            }
            else if (transform.position == waypoint2.position)
            {
                currentWaypoint= waypoint1;
            }
            transform.position = Vector3.MoveTowards(transform.position,currentWaypoint.position,Time.deltaTime*patrolSpeed);
        }
    }
}
