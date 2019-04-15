using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Infrastructure.Database.Interface
{
    public interface IBaseRepositoryQuery<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IList<T>> List();
    }
}
