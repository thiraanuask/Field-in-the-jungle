using System;
using UnityEngine;



    public abstract class FiniteStateMachine : MonoBehaviour
    {
        public State CurrentState { get; set; }
        public State NextState { get; set; }
        public void ProcessFSM()
        {
            if (CurrentState == null) return;
            
            switch (CurrentState.StateStage)
            {
                case StateEvent.ENTER:
                    CurrentState.Enter();
                    break;
                case StateEvent.UPDATE:
                    CurrentState.Update();
                    break;
                case StateEvent.EXIT:
                    //Call current state's Exit()
                    CurrentState.Exit();
                    //Change to the next state
                    CurrentState = NextState;
                    break;
            }
        }

       

        private void Update()
        {
            ProcessFSM();
        }
        
    }

