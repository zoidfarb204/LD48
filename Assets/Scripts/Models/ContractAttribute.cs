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
        public float Value { get; set; }
        
        public float GetModifiedValue()
        {
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
    }
}