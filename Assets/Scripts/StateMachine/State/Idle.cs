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
            rootGameObj.GetComponentInChildren<Animator>().SetFloat("Move", 0f);
        }

        private void LateUpdate()
        {
        }
    }

}