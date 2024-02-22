using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightWeightFSM
{

    public class StateMachine:MonoBehaviour
    {
        [SerializeField]
        private State _initialState;
        private State _currentState;
        private Dictionary<State, List<Transition>> stateMap;
        private void Start()
        {
            _currentState = _initialState;
            stateMap = new Dictionary<State, List<Transition>>();

            foreach(Transform child in transform)
            {
                State s = child.GetComponent<State>();
                if(s!=null)
                {
                    List<Transition> transitions = new List<Transition>();
                    child.GetComponents<Transition>(transitions);
                    stateMap.Add(s, transitions);
                }
            }

            _currentState.OnEnter();
            _currentState.Run();
        }

        private void Update()
        {
            List<Transition> transitions = stateMap[_currentState];
            foreach(Transition s in transitions)
            {
                if(s.toTransition())
                {
                    _currentState.Stop();
                    _currentState.OnExit();
                    _currentState = s.toState;
                    _currentState.OnEnter();
                    _currentState.Run();
                }
            }
        }
    }
}
