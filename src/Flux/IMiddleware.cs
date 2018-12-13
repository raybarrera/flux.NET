namespace Flux {
    interface IMiddleware<TState> {
        TState BeforeAction(IAction<TState> action, TState state);
        TState AfterAction(IAction<TState> action, TState state);
    }
}
