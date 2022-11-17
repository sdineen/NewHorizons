using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.DesignPatterns.Builder
{
    public class Options
    {
        private string connection;
        private Options() { } //can't instantiate class externally

        public class OptionsBuilder
        {
            private string connection;

            //call methods to configure object
            public OptionsBuilder UseInMemoryDatabase(string connection)
            {
                this.connection = connection;
                return this;
            }

            //property builds object
            public Options Options
            {
                get
                {
                    Options options = new Options();
                    options.connection = connection;
                    return options;
                }
            }
        }
    }
}
