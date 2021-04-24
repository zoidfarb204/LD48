using Models;

namespace DefaultNamespace
{
    public interface IAttribute
    {
        void PerformAction(ContractAttribute attribute, bool inverse = false);
    }
}