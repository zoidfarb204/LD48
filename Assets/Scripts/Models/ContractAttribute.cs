using System;
using Enums;
using Singletons;

namespace Models
{
    public class ContractAttribute
    {
        public ContractType ContractType { get; set; }
        public string Text { get; set; }
        public AttributeType AttributeType { get; set; }
        public float ValueMin { get; set; }
        public float ValueMax { get; set; }
        public float Value { get; set; }
        public ContractAttribute()
        {
            
        }

        public float GetModifiedValue(bool inverse = false)
        {
            if (inverse) Value = -Value;
            switch (ContractType)
            {
                case ContractType.Good:
                    return GameStats.Instance.GoodMultiplier * Value;
                case ContractType.Bad:
                case ContractType.Reject:
                    return GameStats.Instance.BadMultiplier * Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ContractType), ContractType, null);
            }
        }

        public int GetModifiedValueInt(bool inverse)
        {
            if (inverse) Value = -Value;
            switch (ContractType)
            {
                case ContractType.Good:
                    return (int) Math.Floor(GameStats.Instance.GoodMultiplier * Value);
                case ContractType.Bad:
                case ContractType.Reject:
                    return (int) Math.Floor(GameStats.Instance.BadMultiplier * Value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(ContractType), ContractType, null);
            }
        }
    }
}