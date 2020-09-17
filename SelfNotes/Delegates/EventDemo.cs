using System;
using System.Threading;
using static System.Console;

namespace Event {
    public class HuntReady : EventArgs {
        public string Prey { get; }
        public HuntReady (string prey) {
            Prey = prey;
        }
    }
    public struct HuntReadyStruct {

    }
    /// <summary>
    /// /ˈprerē/
    /// </summary>
    public class Prairie {
        public event EventHandler<HuntReady> HuntStart;
        public event EventHandler<HuntReadyStruct> HuntStartStruct;
        public void Simulate () {
            int count = 0;
            Random rand = new Random ();
            while (count < 10) {
                count++;
                Thread.Sleep (rand.Next (1, 3) * 1000);
                WriteLine ($"Prey appears!");
                HuntStart?.Invoke (this, new HuntReady ("kill the rabit!"));
            }
        }
    }

    public class Wolf {
        int num;
        public int Num { get; set; }
        public Wolf (Prairie field) {
            field.HuntStart += this.GoHunting;
        }
        public EventHandler<HuntReady> GoHunting = (Object sender, HuntReady e) => {
            WriteLine ($"Go Hunting!! {e.Prey}");
        };
    }
    public static class Event {
        public static void EventDemo () {
            Prairie p = new Prairie ();
            Wolf wolf = new Wolf (p);
            p.Simulate ();
        }
    }
}