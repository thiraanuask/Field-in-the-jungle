
    public abstract class State
    {
        public StateEvent StateStage { get; set; }

        public FiniteStateMachine FSM { get; }

        protected State(FiniteStateMachine fsm)
        {
            FSM = fsm;
            StateStage = StateEvent.ENTER;
        }

        public virtual void Enter()
        {
            //Proceed to the next stage of the FSM state if nothing to setup at the Enter stage
            StateStage = StateEvent.UPDATE;
        }

        public abstract void Update();

        public virtual void Exit()
        {
            StateStage = StateEvent.EXIT;
        }
    }

