using System;

namespace Flux {
    interface IStore<TState> where TState : struct {
        
        event Action StateChanged;

        object Dispatch<TAction>(TAction action) where TAction : IAction<TState>;

        TState GetState();

    }
}
