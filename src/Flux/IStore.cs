using System;

namespace Flux {
    interface IStore<TState> {
        
        TState state { get; }

        event Action StateChanged;

        object Dispatch<TAction>(TAction action) where TAction : IAction;

    }
}
