using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst
{
    public class TipoCampoDomain
    {
        public int IdTipoCampo { get; set; }
        public string NomeTipoCampo { get; set; }

        public virtual ICollection<FormularioCampoDomain> FormularioCampoes  { get; set; }
    }
}
