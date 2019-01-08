using System;
using System.Collections.Generic;

namespace Flux
{
	public class Store<TState> : IStore<TState>, IDisposable
	{
		/// <summary>
		/// Sends an action to the store. This is used to trigger state changes via the sent actions' Reduce() method.
		/// </summary>
		public event Action<StateChangeEventArgs<TState>> OnStateChanged;

		private TState state;
		public TState State
		{
			get
			{
				return state;
			}
		}

		/// <summary>
		/// Middlewares not currently implemented.
		/// </summary>
		//TODO Implement Middleware.
		private List<IMiddleware<TState>> middlewares;

		public Store(TState state)
		{
			this.state = state;
		}

		/// <typeparam name="TAction">TAction must implement the IAction interface.</typeparam>
		/// <param name="action">The action to be dispatched.</param>
		/// <returns></returns>
		public TState Dispatch<TAction>(TAction action) where TAction : IAction<TState>
		{
			TState nextState = action.Reduce(state);

			if (OnStateChanged != null)
			{
				OnStateChanged.Invoke(new StateChangeEventArgs<TState>(state, nextState));
			}

			state = nextState;

			return state;
		}

		Store<TState> Add(IMiddleware<TState> middleware)
		{
			middlewares.Add(middleware);
			return this;
		}

		public void Dispose()
		{
			OnStateChanged = null;
		}

	}

	public class StateChangeEventArgs<TState> : EventArgs
	{
		public TState PreviousState;
		public TState CurrentState;

		public StateChangeEventArgs(TState previous, TState current)
		{
			this.PreviousState = previous;
			this.CurrentState = current;
		}
	}
}
