using System;
using MasterDance.Common;

namespace MasterDance.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}