using Enums;

namespace Models
{
    public class ContractAttribute
    {
        public ContractType ContractType { get; set; }
        public string Text { get; set; }
        public AttributeType AttributeType { get; set; }
        public float Value { get; set; }
    }
}