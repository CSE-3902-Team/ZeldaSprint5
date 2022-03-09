using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0

{
    public interface ICommand
    {
        public void LoadCommand(Object obj);
        public void Execute();
    }
}
