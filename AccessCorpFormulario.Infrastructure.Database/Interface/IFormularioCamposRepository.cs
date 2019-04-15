using AccessCorpFormulario.Infrastructure.Database.CodeFirst;

namespace AccessCorpFormulario.Infrastructure.Database.Interface
{
    public interface IFormularioCamposRepository : IBaseRepositoryAction<FormularioCampoDomain>, IBaseRepositoryQuery<FormularioCampoDomain>
    {
    }
}
