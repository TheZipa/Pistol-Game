using System;
using PistolGame.Code.Infrastructure.StateMachine.States;
using PistolGame.Code.Services;

namespace PistolGame.Code.Infrastructure.StateMachine.GameStateMachine
{
    public interface IGameStateMachine : IGlobalService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
        void AddState<TState>(TState instance) where TState : class, IState;
        void AddState<TState, TPayload>(TState instance) where TState : class, IPayloadedState<TPayload>;
        void AddState(Type type, IExitableState instance);
    }
}