using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AccessCorpFormulario.Domain.ModelView
{
    public class CadastroFormularioCampoModelView
    {
        public int Id { get; set; }

        [Display(Name = "Nome do formulário")]
        [Required(ErrorMessage = "O Nome do Formulário é obrigatório")]
        public string NomeFormulario { get; set; }

        [Display(Name = "Data vencimento início")]
        [Required(ErrorMessage = "A Data de Vencimento do Início é obrigatório")]
        public string DataVencimentoInicio { get; set; }

        [Display(Name = "Data vencimento fim")]
        [Required(ErrorMessage = "A Data de Vencimento do Fim é obrigatório")]
        public string DataVencimentoFim { get; set; }

        [Display(Name = "Descrição formulário")]
        public string DescricaoFormulario { get; set; }

        [Display(Name = "Descrição campo")]
        public string DescricaoCampo { get; set; }

        [Required(ErrorMessage = "O Tipo Campo é obrigatório")]
        [Display(Name = "Tipo de Campo")]
        public int IdTipoCampo { get; set; }
        
        [Required(ErrorMessage = "O Tipo do Valor é obrigatório")]
        [Display(Name = "Tipo do valor de campo")]
        public int IdTipoValorCampo { get; set; }
        
        [Required(ErrorMessage = "O Valor do Campo é obrigatório")]
        [Display(Name = "Valor do Campo")]
        public string ValorCampo { get; set; }
        
        [Display(Name = "Lista do tipo de campo")]
        public List<ListItem> ListaTipoCampo { get; set; }

        [Display(Name = "Lista do tipo do valor de campo")]
        public List<ListItem> ListaTipoValorCampo { get; set; }

        public List<string> MyProperty { get; set; }
    }
}
