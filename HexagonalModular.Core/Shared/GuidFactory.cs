using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalModular.Core.Shared
{
    public static class GuidFactory
    {
        // GUID pseudo-secuencial para .NET 8 // Actualizar en versiones posteriores
        public static Guid NewSequential()
        {
            var guid = Guid.NewGuid().ToByteArray();
            var now = DateTime.UtcNow;

            var ticks = now.Ticks;
            var ticksBytes = BitConverter.GetBytes(ticks);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(ticksBytes);

            Array.Copy(ticksBytes, ticksBytes.Length - 6, guid, 0, 6);

            return new Guid(guid);
        }
    }
}
