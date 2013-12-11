using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class ResultOfOperation
    {
        public bool state;
        public bool end_command_indicator = false;
        public string message;

        public ResultOfOperation()
        { }

        public ResultOfOperation(bool state, string message)
        {
            this.state = state;
            this.message = message;
        }

    }
}
