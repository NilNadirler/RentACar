using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concentre;

namespace DataAccess.Concentre.EntityFramework
{
    public class EfTransactionDal : EfEntityRepositoryBase<Transaction, RecapContext>, ITransactionDal
    {

    }
}
