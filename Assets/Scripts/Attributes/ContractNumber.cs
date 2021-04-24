using DefaultNamespace;
using Models;
using Singletons;

namespace Attributes
{
    public class ContractNumber : IAttribute
    {
        public void PerformAction(ContractAttribute attribute, bool inverse = false)
        {
            GameStats.Instance.UpdateContract(attribute.GetModifiedValueInt(inverse));
        }
    }
}