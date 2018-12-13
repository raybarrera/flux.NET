namespace Flux {
    interface IMiddleware<TState> {
        TState beforeAction(IAction action, TState state);
        TState afterAction(IAction action, TState state);
    }
}
