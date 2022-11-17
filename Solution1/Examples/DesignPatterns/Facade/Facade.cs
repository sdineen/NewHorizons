using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Facade
{
    public class Facade
    {
        private Engine engine = new Engine();
        private Lights lights = new Lights();
        private Radio radio = new Radio();

        public void Start()
        {
            engine.Start();
            lights.On();
            radio.On();
        }
        public void Stop()
        {
            engine.Stop();
            lights.Off();
            radio.Off();
        }
    }
}
