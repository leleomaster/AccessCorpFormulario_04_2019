using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessCorpFormulario.AplicationService.Service.Interfaces
{
    public interface IBaseAplicationServiceQuery<T> where T : class
    {
        T GetById(int id);
        Task<IList<T>> List();
    }
}
