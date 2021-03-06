using Flux;
using System;

namespace FluxSample {
    class State {
        private readonly int count;
        public int Count => count;

        public State(int count) {
            this.count = count;
        }

        public override string ToString() {
            return count.ToString();
        }
    }

    class Increment : IAction<State> {
        private readonly int by;

        public Increment(int by = 1) {
            this.by = by;
        }

        public State Reduce(State state) {
            return new State(state.Count + by);
        }
    }

    class Program {
        static void Main(string[] args) {
            Store<State> store = new Store<State>(new State(0));

            store.OnStateChanged += () =>
            {
                Console.WriteLine(store.State.Count);
            };

            store.Dispatch(new Increment());
            Console.ReadLine();
        }
    }
}
