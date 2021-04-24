using DefaultNamespace;
using Enums;
using Models;
using Singletons;

namespace Attributes
{
    public class ContractTimePercent: IAttribute
    {
        public void PerformAction(ContractAttribute attribute, bool inverse = false)
        {
            var time = GameStats.Instance.TimePerContract;
            time = time + (attribute.GetModifiedValue(inverse) * time);
            GameStats.Instance.ChangeValue(StatType.TimePerContract, time);
        }
    }
}