using AccessCorpFormulario.AplicationService.Service.Interfaces;
using AccessCorpFormulario.Domain.ModelView;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessCorpFormulario.AplicationService.Service.Implementations
{
    public class TipoCampoApplicationService : ITipoCampoApplicionServie
    {
        public TipoCampoModelView GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TipoCampoModelView>> List()
        {
            throw new NotImplementedException();
        }
    }
}
