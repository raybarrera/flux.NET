namespace Flux {
    interface IAction<TState> {
        TState Reduce(TState state);
    }
}
