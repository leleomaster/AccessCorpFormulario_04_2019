using AccessCorpFormulario.AplicationService.Service.Interfaces;
using AccessCorpFormulario.Domain.ModelView;
using AccessCorpFormulario.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AccessCorpFormulario.Web.Controllers
{
    public class FormularioController : Controller
    {
        IFormularioApplicionServie _formularioApplicionServie;

        public FormularioController(IFormularioApplicionServie formularioApplicionServie)
        {
            _formularioApplicionServie = formularioApplicionServie;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            var model = new CadastroFormularioCampoModelView();
            
            model.ListaTipoCampo = MockModelView.ListaTipoCampo();
            model.ListaTipoValorCampo = MockModelView.ListaTipoValorCampo();

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Lista()
        {
            var lista  = await _formularioApplicionServie.List();

            return View(lista.ToList());
        }

        [HttpGet]
        public ActionResult Exibir(int id)
        {
            var formulario = _formularioApplicionServie.GetById(id);

            return View(formulario);
        }

    }
}