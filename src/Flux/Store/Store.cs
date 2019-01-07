using System;
using System.Collections.Generic;

namespace Flux {
    public class Store <TState> : IStore <TState>, IDisposable {

        private TState state;
        public TState State => state;

        public event Action OnStateChanged;

        /// <summary>
        /// Middlewares not currently implemented.
        /// </summary>
        //TODO Implement Middleware.
        private List<IMiddleware<TState>> middlewares;

        public Store(TState initialState) {
            this.state = initialState;
        }

        /// <summary>
        /// Sends an action to the store. This is used to trigger state changes via the sent actions' Reduce() method.
        /// </summary>
        /// <typeparam name="TAction">TAction must implement the IAction interface.</typeparam>
        /// <param name="action">The action to be dispatched.</param>
        /// <returns></returns>
        public TState Dispatch<TAction>(TAction action) where TAction : IAction<TState> {
            state = action.Reduce(state);
            if (OnStateChanged != null)
            {
                OnStateChanged.Invoke();
            }
            return state;
        }

        Store<TState> Add(IMiddleware<TState> middleware) {
            middlewares.Add(middleware);
            return this;
        }

        public void Dispose()
        {
            OnStateChanged = null;
        }
    }
}
