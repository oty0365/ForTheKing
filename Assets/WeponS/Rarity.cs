using System;

namespace WeponS
{
    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Unknown
    }

    public static class RarityExtension
    {
        public static string ToName(this Rarity rarity)
        {
            return rarity switch
            {
                Rarity.Common => "일반",
                Rarity.Rare => "희귀",
                Rarity.Epic => "영웅",
                Rarity.Legendary => "전설",
                Rarity.Unknown => "불명",
                _ => throw new ArgumentOutOfRangeException(nameof(rarity), rarity, null)
            };
        }
    }
}