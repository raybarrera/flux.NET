using System;
using System.Reactive.Linq;

namespace Flux.Rx
{
    public static class StoreExtensions
    {
        public static IObservable<TState> ObserveState<TState>(this IStore<TState> store)
        {
            return Observable
                .FromEvent(
                    e => store.OnStateChanged += e,
                    e => store.OnStateChanged -= e
                )
                .Select(_ => store.State);
        }
    }
}