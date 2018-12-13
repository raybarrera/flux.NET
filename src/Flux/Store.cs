using System.Collections.Generic;

namespace Flux {
    public class Store <TState> : IStore <TState> {

        private TState state;
        public TState State => state;

        /// <summary>
        /// Middlewares not currently implemented.
        /// </summary>
        //TODO Implement Middlewares.
        private List<IMiddleware<TState>> middlewares;

        public Store(TState state) {
            this.state = state;
        }

        /// <summary>
        /// Sends an action to the store. This is used to trigger state changes via the sent actions' Reduce() method.
        /// </summary>
        /// <typeparam name="TAction">TAction must implement the IAction interface.</typeparam>
        /// <param name="action">The action to be dispatched.</param>
        /// <returns></returns>
        public TState Dispatch<TAction>(TAction action) where TAction : IAction<TState> {
            //TODO: This is obviously incorrect. We need to store the state in the store, and we need to provide immutability.
            state = action.Reduce(state);
            return state;
        }

        Store<TState> Add(IMiddleware<TState> middleware) {
            middlewares.Add(middleware);
            return this;
        }
    }
}
