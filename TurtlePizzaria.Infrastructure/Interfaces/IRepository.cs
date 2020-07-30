using TurtlePizzaria.Core.Data;

namespace TurtlePizzaria.Infrastructure.Interfaces
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
