using System;

namespace Flux {
    class Store <TState> : IStore<TState> where TState : struct {

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
        public object Dispatch<TAction>(TAction action) where TAction : IAction<TState> {

            //TODO: This is obviously incorrect. We need to store the state in the store, and we need to provide immutability.
            TState result = action.Reduce(GetState());
            return result;
        }

        /// <summary>
        /// TODO this should be a property.
        /// </summary>
        /// <returns></returns>
        public TState GetState() {
            throw new NotImplementedException();
        }
    }
}
