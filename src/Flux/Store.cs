using System.Collections.Generic;

namespace Flux {
    public class Store <TState> : IStore <TState> {

        private TState state;
        public TState State => state;

        /// <summary>
        /// Middlewares not currently implemented.
        /// </summary>
        //TODO Implement Middleware.
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
            state = action.Reduce(state);
            return state;
        }

        Store<TState> Add(IMiddleware<TState> middleware) {
            middlewares.Add(middleware);
            return this;
        }
    }
}
