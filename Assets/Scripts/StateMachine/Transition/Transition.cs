using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightWeightFSM
{

    public abstract class Transition:MonoBehaviour
    {
        [SerializeField]
        public State fromState;
        [SerializeField]
        public State toState;

        public abstract bool toTransition();
    }

}