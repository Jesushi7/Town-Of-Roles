using Hazel;
using Reactor.Networking.Attributes;
using Reactor.Networking.Rpc;

namespace TownOfUs.Lobby.CrowdedMod.Net
{
    [RegisterCustomRpc((uint)TownOfUsReworked.Lobby.CrowdedMod.Net.CustomRpcCalls.SetColor)]
    public class SetColorRpc : PlayerCustomRpc<TownOfUs, byte>
    {
        public SetColorRpc(TownOfUs plugin, uint id) : base(plugin, id) {}

        public override RpcLocalHandling LocalHandling => RpcLocalHandling.After;

        public override void Write(MessageWriter writer, byte data)
        {
            writer.Write(data);
        }

        public override byte Read(MessageReader reader)
        {
            return reader.ReadByte();
        }

        public override void Handle(PlayerControl player, byte data)
        {
            player.SetColor(data);
        }
    }
}