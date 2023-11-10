namespace PacketLibrary.VSRO188.Agent.Enums.Character;

public enum CharacterInfoUpdateType : byte
{
    ///<summary>
    /// New value from gold at inventory
    ///</summary>
    Gold = 1,

    ///<summary>
    /// New value from skill points to spend
    ///</summary>
    SP = 2,
  
    STP = 3, // Stat points

    ///<summary>
    /// New value for berserker mode (5 points = Ready)
    ///</summary>
    HWAN = 4,
    
    // UIIT_STT_EGYPT_AP_POINT_RECOVER_RESULT
    EGYPT_AP = 16,
}