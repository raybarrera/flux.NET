using System;

namespace Flux {
    class Store <TState> : IStore<TState> {

        public TState state => throw new NotImplementedException();

        /// <summary>
        /// Middlewares not currently implemented.
        /// </summary>
        //TODO Implement Middlewares.
        private readonly IMiddleware<TState>[] middlewares;


        /// <summary>
        /// Action to be called whenever the state changes.
        /// </summary>
        public event Action StateChanged;

        /// <summary>
        /// Sends an action to the store. This is used to trigger state changes via the sent actions' Reduce() method.
        /// </summary>
        /// <typeparam name="TAction">TAction must implement the IAction interface.</typeparam>
        /// <param name="action">The action to be dispatched.</param>
        /// <returns></returns>
        public object Dispatch<TAction>(TAction action) where TAction : IAction {

            //TODO: This is obviously incorrect. We need to store the state in the store, and we need to provide immutability.
            object result = action.Reduce(state);
            return result;
        }
    }
}
