namespace API.Objects.Cos;

public interface IGrowth : ICos
{
    ushort CurrentHungerPoints { get; set; }
    ushort MaxHungerPoints => 10000;
    bool IsOffensive => (Settings & 1) == 1;
}