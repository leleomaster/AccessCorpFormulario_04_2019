using System.Collections.Generic;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst
{
    public class FormularioCampoDomain
    {
        public int IdFormulario { get; set; }
        public int IdTipoCampo { get; set; }
        public int IdTipoValorCampo { get; set; }
        public int IdFormularioCampo { get; set; }

        public string DescricaoCampo { get; set; }

        public virtual FormularioDomain Formulario { get; set; }
        public virtual TipoCampoDomain TipoCampo { get; set; }
        public virtual TipoValorCampoDomain TipoValorCampo { get; set; }

        public virtual ICollection<ValorCampoDomain> ValorCampoes { get; set; }
    }
}
