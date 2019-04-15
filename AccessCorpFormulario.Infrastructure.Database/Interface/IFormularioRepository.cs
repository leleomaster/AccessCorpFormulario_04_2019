using AccessCorpFormulario.Infrastructure.Database.CodeFirst;

namespace AccessCorpFormulario.Infrastructure.Database.Interface
{
    public interface IFormularioRepository : IBaseRepositoryAction<FormularioDomain>, IBaseRepositoryQuery<FormularioDomain>
    {
    }
}
