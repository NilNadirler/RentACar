using Core.DataAccess;
using Entities.Concentre;

namespace DataAccess.Abstract
{
    public interface ITransactionDal : IEntityRepository<Transaction>
    {
    }
}
