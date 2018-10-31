using Mithril;
using System;

namespace LibPotato
{
    public class Packet
    {
        public EPacketType Type { get; private set; }
        public bool IsReliable { get; private set; }

        public Packet(EPacketType type, bool reliable = true)
        {
            Type = type;
            IsReliable = reliable;
        }

        public void Write(Mithril.Buffer buffer)
        {
            WriteHeader(buffer);
            WriteData(buffer);
        }

        private void WriteHeader(Mithril.Buffer buffer)
        {
            buffer.WriteShort((short)Type);
        }

        protected virtual void WriteData(Mithril.Buffer buffer)
        {

        }

        public void Read(Mithril.Buffer buffer)
        {
            ReadHeader(buffer);
            ReadData(buffer);
        }

        private void ReadHeader(Mithril.Buffer buffer)
        {
            Type = (EPacketType)buffer.ReadShort();
        }

        protected virtual void ReadData(Mithril.Buffer buffer)
        {

        }
    }
}
