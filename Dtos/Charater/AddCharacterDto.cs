using dotnet_rpg.Models;

namespace dotnet_rpg.Dtos.Charater
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defensive { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass CharacterClass { get; set; }= RpgClass.Knight;
    }
}