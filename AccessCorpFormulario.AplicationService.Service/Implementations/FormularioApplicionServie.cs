using AccessCorpFormulario.AplicationService.Service.Interfaces;
using AccessCorpFormulario.Domain.ModelView;
using AccessCorpFormulario.Domain.ModelView.Mappers;
using AccessCorpFormulario.Infrastructure.Database.CodeFirst;
using AccessCorpFormulario.Infrastructure.Database.CodeFirst.Interfaces;
using AccessCorpFormulario.Infrastructure.Database.CodeFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace AccessCorpFormulario.AplicationService.Service.Implementations
{
    public class FormularioApplicionServie : IFormularioApplicionServie
    {
        private readonly UnitOfWork _db;

        public FormularioApplicionServie(UnitOfWork db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var formulario = _db.FormularioCampoRepositorio.GetAll(x => x.IdFormulario == id).SingleOrDefault();

            if (formulario != null)
            {
                _db.FormularioCampoRepositorio.Delete(formulario);
                _db.Commit();
            }
        }

        public FormularioModelView GetById(int id)
        {
            var formularioDomain = _db.FormularioRepositorio.Get(f => f.IdFormulario == id);

            var formularioModelView = FormularioMapper.FormularioModelViewToFormularioDomain(formularioDomain);

            return formularioModelView;
        }

        public void Insert(FormularioModelView t)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var formularioDomain = FormularioMapper.FormularioDomainToFormularioModelView(t);

                var _forma = new FormularioDomain()
                {
                    DataVencimentoFim = formularioDomain.DataVencimentoFim,
                    DataVencimentoInicio = formularioDomain.DataVencimentoInicio,
                    DescricaoFormulario = formularioDomain.DescricaoFormulario,
                    NomeFormulario = formularioDomain.NomeFormulario
                };

                _db.FormularioRepositorio.Insert(_forma);
                _db.Commit();

                var idFormulario = _forma.IdFormulario;

                foreach (var formularioCampo in formularioDomain.FormularioCampoes)
                {

                    var _formularioCampo = new FormularioCampoDomain
                    {
                        IdFormulario = idFormulario,
                        IdTipoCampo = formularioCampo.IdTipoCampo,
                        IdTipoValorCampo = formularioCampo.IdTipoValorCampo,
                        DescricaoCampo = formularioCampo.DescricaoCampo
                    };

                    _db.FormularioCampoRepositorio.Insert(_formularioCampo);
                    _db.Commit();

                    var idFormularioCampo = _formularioCampo.IdFormularioCampo;

                    foreach (var valorCampo in formularioCampo.ValorCampoes)
                    {
                        var _valorCampo = new ValorCampoDomain
                        {
                            IdFormularioCampo = idFormularioCampo,
                            ValorCampo = valorCampo.ValorCampo
                        };

                        _db.ValorCampoRepositorio.Insert(_valorCampo);
                    }
                    _db.Commit();
                }

                scope.Complete();
            }
        }

        public async Task<IList<FormularioModelView>> List()
        {
            var lista = await _db.FormularioRepositorio.GetAllAsync();

            var listaFormulario = FormularioMapper.FormularioModelViewToFormularioDomain(lista.ToList());

            return listaFormulario;
        }

        public async void Update(FormularioModelView t)
        {
            var lista = await _db.FormularioRepositorio.GetAllAsync(x => x.IdFormulario == t.IdFormulario);

            var formularioDomain = lista.FirstOrDefault();

            if (formularioDomain != null)
            {
                formularioDomain.DataVencimentoFim = Convert.ToDateTime(t.DataVencimentoInicio, System.Globalization.CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat);
                formularioDomain.DataVencimentoInicio = Convert.ToDateTime(t.DataVencimentoInicio, System.Globalization.CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat);
                formularioDomain.DescricaoFormulario = t.DescricaoFormulario;
                formularioDomain.NomeFormulario = t.NomeFormulario;

                _db.FormularioRepositorio.Update(formularioDomain);
                _db.CommitAsync();
            }
        }
    }
}
