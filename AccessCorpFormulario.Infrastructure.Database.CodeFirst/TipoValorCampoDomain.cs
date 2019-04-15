using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst
{
    public class TipoValorCampoDomain
    {
        public int IdTipoValorCampo { get; set; }
        public string NomeTipoValorCampo { get; set; }

        public virtual ICollection<FormularioCampoDomain> FormularioCampoes { get; set; }
    }
}
