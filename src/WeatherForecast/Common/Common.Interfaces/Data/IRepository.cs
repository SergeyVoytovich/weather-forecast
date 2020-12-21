using Common.Interfaces.Models;

namespace Common.Interfaces.Data
{
    public interface IRepository
    {
        ICity Get(string name);
        ICity Get(int zipCode);
    }
}