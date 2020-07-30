namespace TurtlePizzaria.Core.Data
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}