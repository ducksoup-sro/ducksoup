## Packet Rework
- I don't like the way the "encrypted" part is stored
  - a better way could be to store it as bool and do the rest on the read / write packet
  - on the MsgId property we should just check the bool and return either shifted, or raw return
- Initialize should also have a internal boolean that's set to prevent multiple initializations
- Initialize should have a overload with a MsgId to "just set a packet"
  - we could set the size and security bytes to 0 

#### Conclusion: We don't need any of this. The MsgId can just be set and the read / write is controlled via. the TryRead/TryWrite.