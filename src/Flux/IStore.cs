using System;

namespace Flux {
    public interface IStore<TState> {
        
        /// <summary>
        /// Required property that returns the state contained in the store.
        /// </summary>
        TState State { get; }

        TState Dispatch<TAction>(TAction action) where TAction : IAction<TState>;
    }
}
