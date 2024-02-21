using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightWeightFSM
{
    public class TimeInterval : Transition
    {
        [SerializeField]
        private int m_Interval;
        public override bool toTransition()
        {
            bool result = false;
            float interval = Time.time - fromState.enterTime;
            if(interval>m_Interval) result= true;
            return result;
        }

    }
}
