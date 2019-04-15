using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst
{
    public class FormularioDomain
    {
        public int IdFormulario { get; set; }
        public string NomeFormulario { get; set; }
        public System.DateTime? DataVencimentoInicio { get; set; }
        public System.DateTime? DataVencimentoFim { get; set; }
        public string DescricaoFormulario { get; set; }

        public virtual ICollection<FormularioCampoDomain> FormularioCampoes { get; set; }        
    }
}
