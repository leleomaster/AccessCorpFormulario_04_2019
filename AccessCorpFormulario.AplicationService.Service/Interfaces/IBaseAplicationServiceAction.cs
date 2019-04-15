using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessCorpFormulario.AplicationService.Service.Interfaces
{
    public interface IBaseAplicationServiceAction<T> where T : class
    {
        void Delete(int id);
        void Update(T t);
        void Insert(T t);
    }
}
