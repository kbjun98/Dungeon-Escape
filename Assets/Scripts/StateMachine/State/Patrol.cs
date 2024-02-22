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

        public override void OnEnter()
        {
            base.OnEnter();
            currentWaypoint = waypoint1;
            rootGameObj.GetComponentInChildren<Animator>().SetFloat("Move",patrolSpeed);
        }

        private void LateUpdate()
        {
            if (rootGameObj.transform.position == waypoint1.position)
            {
                currentWaypoint= waypoint2;
            }
            else if (rootGameObj.transform.position == waypoint2.position)
            {
                currentWaypoint= waypoint1;
            }
            rootGameObj.transform.position = Vector3.MoveTowards(rootGameObj.transform.position,currentWaypoint.position,Time.deltaTime*patrolSpeed);
        }
    }
}
