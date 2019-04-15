using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositorioBase<FormularioDomain> FormularioRepositorio { get; }
        IRepositorioBase<FormularioCampoDomain> FormularioCampoRepositorio { get; }
        IRepositorioBase<ValorCampoDomain> ValorCampoRepositorio { get; }

        void Commit();
        void CommitAsync();
    }
}
