namespace API.Enums;

public enum UserRole : byte
{
    SuperAdmin = 0xFF, // 255
    Owner = 0x46, // 70
    Admin = 0x32, // 50
    Mod = 0x1E, // 30
    User = 0xA, // 10

    // Do not use, functional roles
    Authenticated = 0x2,
    Anyone = 0x1, //  
    Anonymous = 0x0 //
}