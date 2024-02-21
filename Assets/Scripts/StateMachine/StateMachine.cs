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
        private List<Transition> transitions;
        private List<State> states;
        private void Start()
        {
            _currentState = _initialState;
            transitions= new List<Transition>();
            states= new List<State>();
            GetComponents(transitions);
            Debug.Log(transitions.Count);
            GetComponents(states);
            Debug.Log(states.Count);
        }

        private void Update()
        {
            foreach(Transition tr in transitions)
            {
                if(_currentState.Equals(tr.fromState))
                {
                    if (tr.toTransition())
                    {
                        _currentState.Stop();
                        _currentState.OnExit();
                        _currentState= tr.toState;
                        _currentState.Run();
                        _currentState.OnEnter();
                    }
                }
            }
        }
    }
}
