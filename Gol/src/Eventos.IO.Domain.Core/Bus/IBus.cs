using Gol.IO.Domain.Core.Commands;
using Gol.IO.Domain.Core.Events;

namespace Gol.IO.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
