namespace CR.Servers.CoC.Packets.Commands.Client.Unknown
{
    using CR.Servers.CoC.Logic;
    using CR.Servers.Extensions.Binary;

    internal class Unknown_605 : Command
    {
        public Unknown_605(Device Device, Reader Reader) : base(Device, Reader)
        {
        }

        internal override int Type
        {
            get
            {
                return 605;
            }
        }
    }
}