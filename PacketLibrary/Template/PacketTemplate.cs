using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Template;

// Original Link - Example: https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_LOGIN#ibuv-confirm-request
public class PacketTemplate : Packet
{
    // msgId, encrypted, massive
    public PacketTemplate() : base(0x0000, false, false)
    {
    }

    // From = where is the packet coming from? is it coming from the PacketDirection.CLIENT to the Server?
    // To = where is it supposed to land? Usually Server or Filter.
    // Usually its marked as Filter if its a non existing Packet, meaning it would crash the Server / throw a dc
    public override PacketDirection FromDirection => PacketDirection.None;
    public override PacketDirection ToDirection => PacketDirection.None;


    public uint Test123;
    
    // Design how the packet is read by default.. There multiple ways to do this
    // 1. write //empty if its empty
    // 2. throw NotImplementedException if its not read
    // 3. remove the NotImplementedException and let it be empty if you wanna read it 'on the fly' but not build it again
    // 4. fully read it
    public override async Task Read()
    {
        // 1. empty
        // 2. throw new NotImplementedException();
        // 3. nothing
        // 4. Example 1. - Read it locally 
        TryRead<byte>(out var test);
        TryRead(out string ThisIsAString);
        
        // 4. Example 2. - Read it in a way it can be modified and rebuild
        TryRead<uint>(out Test123);
    }

    // If you choose to use 3. nothing do NOT reset() the packet. It will empty the current PacketPayload.
    // If you want to rewrite it and have the full structure do the following
    public override async Task<Packet> Build()
    {
        // 1. Reset first to empty out the old data
        // 2. write your package contents, usually its the reversed read version. The If's should be the same
        // 3. return this packet
        
        Reset();
        
        TryWrite<uint>(Test123);
        
        return this;
    }

    // Usually I include one empty "of" and multiple versions of the Packet, for example the chat packet can have multiple fields filled out
    public static Packet of()
    {
        return new PacketTemplate();
    }
    
    public static Packet of(uint test123)
    {
        return new PacketTemplate
        {
            Test123 = test123
        };
    }
}