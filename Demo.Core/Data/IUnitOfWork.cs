namespace Demo.Core.Data
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}