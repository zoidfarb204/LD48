using DefaultNamespace;
using Enums;
using Models;
using Singletons;

namespace Attributes
{
    public class GoodQualityPercent : IAttribute
    {
        public void PerformAction(ContractAttribute attribute, bool inverse = false)
        {
            var goodMultiplier = GameStats.Instance.GoodMultiplier;
            var amountChange = goodMultiplier * (attribute.GetModifiedValue(inverse)/100);
            goodMultiplier = goodMultiplier + amountChange;
            GameStats.Instance.ChangeValue(StatType.GoodMultiplier, goodMultiplier);
        }
    }
}