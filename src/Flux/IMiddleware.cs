namespace Flux {
    interface IMiddleware<TState> {
        TState beforeAction(IAction<TState> action, TState state);
        TState afterAction(IAction<TState> action, TState state);
    }
}
