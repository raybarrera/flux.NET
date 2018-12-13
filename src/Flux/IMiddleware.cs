namespace Flux {
    interface IMiddleware<TState> {
        TState BeforeAction(IAction action, TState state);
        TState AfterAction(IAction action, TState state);
    }
}
