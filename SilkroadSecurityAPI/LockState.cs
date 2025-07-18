namespace SilkroadSecurityAPI;

public enum LockState
{
    None,
    ChangeIdentity,
    GenerateSecurity,
    Send,
    Recv,
    TransferIncoming,
    TransferOutgoing,
    TransferOutgoingNewClient,
    TransferOutgoingNewSession
}