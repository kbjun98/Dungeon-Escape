using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightWeightFSM
{

    public class Idle : State
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GetComponentInChildren<Animator>().SetTrigger("Idle");
        }

        private void LateUpdate()
        {
            Debug.Log("Idle LateUpdate");
        }
    }

}