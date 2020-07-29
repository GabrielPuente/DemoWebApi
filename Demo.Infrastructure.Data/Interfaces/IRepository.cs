using Demo.Core.Data;

namespace Demo.Infrastructure.Data.Interfaces
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
