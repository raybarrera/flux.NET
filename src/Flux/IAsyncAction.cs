namespace Flux
{
    public interface IAsyncAction<TState>
    {
        /// <summary>
        /// TODO Implement!
        /// </summary>
        /// <param name="state"></param>
        void Reduce(TState state);    
    }
}