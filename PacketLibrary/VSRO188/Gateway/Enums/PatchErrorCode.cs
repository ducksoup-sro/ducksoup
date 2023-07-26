namespace PacketLibrary.VSRO188.Gateway.Enums;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/PatchErrorCodes
public enum PatchErrorCode : byte
{
    /// <summary>
    ///     UILM_MSG_DETECTED_ABNORMAL_MODULE
    ///     <para>Invalid client. Program will be terminated.</para>
    /// </summary>
    InvalidVersion = 1,

    /// <summary>
    ///     BSObj Plugin: can't create file transfer manager! Maybe pack file corrupted or someone is already accessing it
    ///     now... try a few minutes later"
    /// </summary>
    Update = 2,

    /// <summary>
    ///     UILM_MSG_GATEWAY_NOT_IN_SERVICE
    ///     <para>The server is undergoing inspection or updates. Connect to %swww.silkroadonline.net for more information.</para>
    /// </summary>
    NotInService = 3,

    /// <summary>
    ///     UILM_MSG_DETECTED_ABNORMAL_MODULE
    ///     <para>Invalid client. Program will be terminated.</para>
    /// </summary>
    AbnormalModule = 4,

    /// <summary>
    ///     UILM_MSG_DETECTED_PATCH_DIABLE
    ///     <para>You have to install the full version. Move to official website to dowload the full version?</para>
    /// </summary>
    PatchDisabled = 5
}