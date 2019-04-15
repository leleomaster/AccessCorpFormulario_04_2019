using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst
{
    public class ValorCampoDomain
    {
        public int IdValorCampo { get; set; }
        public int IdFormularioCampo { get; set; }

        public string ValorCampo { get; set; }

        public virtual FormularioCampoDomain Formulario { get; set; }
    }
}
