using DefaultNamespace;
using Enums;
using Models;
using Singletons;

namespace Attributes
{
    public class BadQualityPercent :IAttribute
    {
        public void PerformAction(ContractAttribute attribute)
        {
            var badMultiplier = GameStats.Instance.BadMultiplier;
            var amountChange = badMultiplier * (attribute.Value/100);
            badMultiplier = badMultiplier + amountChange;
            GameStats.Instance.ChangeValue(StatType.BadMultiplier, badMultiplier);
        }
    }
}