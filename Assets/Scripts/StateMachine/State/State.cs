using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LightWeightFSM
{
    public class State:MonoBehaviour
    {
        public float enterTime { get; private set; }
        public float exitTIme { get; private set; }
        private void Start()
        {
            enabled= false;
        }

        public void Run()
        {
            enabled= true;
        }
        public void Stop()
        {
            enabled= false;
        }

        public virtual void OnEnter() 
        { 
            enterTime= Time.time;
        }

        public virtual void OnExit() 
        {
            exitTIme= Time.time;
        }
    }
}
