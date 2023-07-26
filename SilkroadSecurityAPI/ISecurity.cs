using System.Collections.Generic;
using NetCoreServer;
using SilkroadSecurityAPI.Message;

namespace SilkroadSecurityAPI;

public interface ISecurity
{
    void ChangeIdentity(string name, byte flag);
    void GenerateSecurity(bool blowfish, bool security_bytes, bool handshake);
    void Send(Packet packet);
    void Recv(byte[] buffer, int offset, int length);
    void Recv(TransferBuffer rawBuffer);
    List<Packet> TransferIncoming();
    void TransferOutgoing(TcpSession session);
    void TransferOutgoing(TcpClient client);
}