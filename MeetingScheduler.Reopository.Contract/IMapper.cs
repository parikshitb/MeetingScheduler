using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Repository.Contract
{
    public interface IMapper
    {
        IList<TEntity> SqlToEntity<TEntity>(IDataReader dr) where TEntity : class;
    }
}
