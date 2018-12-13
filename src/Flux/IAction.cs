namespace Flux {
    public interface IAction<TState> {
        /// <summary>
        /// Takes the place of the "reducer" object in traditional flux implementations.
        /// This returns a new state that has been NEW modified by the action itself.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        TState Reduce(TState state);
    }
}