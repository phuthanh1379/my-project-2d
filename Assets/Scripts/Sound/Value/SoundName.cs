using System.Collections.Generic;

namespace Sound.Value
{
    public struct SoundName
    {
        public const string RockBreaking = "RockBreaking";
        public const string Maniac = "Maniac";
        public const string UpAndRight = "UpAndRight";
        public const string HurtAndHeart = "HurtAndHeart";
        public const string Type1 = "Type1";
        public const string Type2 = "Type2";
        public const string Type3 = "Type3";
        public const string Type4 = "Type4";
        public const string Type5 = "Type5";
        public const string Type6 = "Type6";
        public const string Type7 = "Type7";
        public const string Sword1 = "Sword1";

        public static readonly List<string> SoundNames = new List<string>()
        {
            RockBreaking,
            Maniac,
            UpAndRight,
            HurtAndHeart,
            Type1,
            Type2,
            Type3,
            Type4,
            Type5,
            Type6,
            Type7,
            Sword1,
        };

        public bool CheckName(string name)
        {
            return !string.IsNullOrEmpty(name) && SoundNames.Contains(name);
        }
    }
}