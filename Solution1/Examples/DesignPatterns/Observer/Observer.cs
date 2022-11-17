using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Examples.DesignPatterns.Observer
{

    public interface IObserver
    {
        void Notify(object sender, EventArgs e);
    }

    public class Observer : IObserver
    {
        public void Notify(object sender, EventArgs e)
        {
            Console.WriteLine("Observer Notify called");
        }
    }

    public class Observable
    {
        private event EventHandler Event1;

        public Observable()
        {
            Timer timer = new Timer(5000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
            => Event1(this, new EventArgs());
       
        public void RegisterObserver(EventHandler handler)
            => Event1 += handler;        
    }

    public class Class1
    {
        public static void Main()
        {
            IObserver observer = new Observer();
            Observable observable = new Observable();
            observable.RegisterObserver(observer.Notify);
            Console.ReadKey();
        }
    }
}
