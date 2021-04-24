using DefaultNamespace;
using Enums;
using Models;
using Singletons;

namespace Attributes
{
    public class BadQualityPercent :IAttribute
    {
        public void PerformAction(ContractAttribute attribute, bool inverse = false)
        {
            var badMultiplier = GameStats.Instance.BadMultiplier;
            var amountChange = badMultiplier * (attribute.GetModifiedValue(inverse)/100);
            badMultiplier = badMultiplier + amountChange;
            GameStats.Instance.ChangeValue(StatType.BadMultiplier, badMultiplier);
        }
    }
}