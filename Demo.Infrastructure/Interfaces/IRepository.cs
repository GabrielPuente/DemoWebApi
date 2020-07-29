using Demo.Core.Data;

namespace Demo.Infrastructure.Interfaces
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
