using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Services.Interfaces
{
    public interface ITimerManager
    {
        void Execute(object stateInfo);
    }
}
