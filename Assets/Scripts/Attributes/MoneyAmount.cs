using DefaultNamespace;
using Enums;
using Models;
using Singletons;

namespace Attributes
{
    public class MoneyAmount: IAttribute
    {
        public void PerformAction(ContractAttribute attribute, bool inverse = false)
        {
            var money = GameStats.Instance.Money;
            money = money + attribute.GetModifiedValue(inverse);
            GameStats.Instance.ChangeValue(StatType.Money, money);
        }
    }
}