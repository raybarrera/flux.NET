using System;

namespace Flux {
    interface IStore<TState> {
        
        TState State { get; }

        event Action StateChanged;

        TState Dispatch<TAction>(TAction action) where TAction : IAction;

    }
}
