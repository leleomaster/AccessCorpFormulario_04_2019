using AccessCorpFormulario.Infrastructure.Database.CodeFirst;
using System;
using System.Collections.Generic;

namespace AccessCorpFormulario.Domain.ModelView.Mappers
{
    public static class FormularioMapper
    {
        public static FormularioDomain FormularioDomainToFormularioModelView(FormularioModelView formularioModelView)
        {
            var formularioDomain = new FormularioDomain();

            if (formularioModelView != null)
            {
                formularioDomain.IdFormulario = formularioModelView.IdFormulario;
                formularioDomain.NomeFormulario = formularioModelView.NomeFormulario;
                formularioDomain.DescricaoFormulario = formularioModelView.DescricaoFormulario;
                formularioDomain.DataVencimentoInicio = Convert.ToDateTime(formularioModelView.DataVencimentoInicio, System.Globalization.CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat);
                formularioDomain.DataVencimentoFim = Convert.ToDateTime(formularioModelView.DataVencimentoFim, System.Globalization.CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat);

                if (formularioModelView.FormularioCampos != null && formularioModelView.FormularioCampos.Count > 0)
                {
                    FormularioCampoDomain formularioCampoDomain = null;
                    formularioDomain.FormularioCampoes = new List<FormularioCampoDomain>();

                    foreach (var formularioCampo in formularioModelView.FormularioCampos)
                    {
                        formularioCampoDomain = new FormularioCampoDomain();
                        formularioCampoDomain.IdTipoCampo = formularioCampo.IdTipoCampo;
                        formularioCampoDomain.IdTipoValorCampo = formularioCampo.IdTipoValorCampo;
                        formularioCampoDomain.DescricaoCampo = formularioCampo.DescricaoCampo;

                        formularioCampoDomain.TipoValorCampo = new TipoValorCampoDomain { IdTipoValorCampo = formularioCampo.IdTipoValorCampo };
                        formularioCampoDomain.TipoCampo = new TipoCampoDomain { IdTipoCampo = formularioCampo.IdTipoCampo };

                        formularioDomain.FormularioCampoes.Add(formularioCampoDomain);

                        if (formularioCampo.ValorCampos != null && formularioCampo.ValorCampos.Count > 0)
                        {
                            formularioCampoDomain.ValorCampoes = new List<ValorCampoDomain>();

                            foreach (var valorCampos in formularioCampo.ValorCampos)
                            {
                                formularioCampoDomain.ValorCampoes.Add(new ValorCampoDomain()
                                {
                                    ValorCampo = valorCampos.ValorCampo,
                                    IdFormularioCampo = valorCampos.IdFormulario,
                                    IdValorCampo = valorCampos.IdValorCampo
                                });
                            }
                        }
                    }
                }

              
            }

            return formularioDomain;
        }

        public static List<FormularioModelView> FormularioModelViewToFormularioDomain(List<FormularioDomain> lista)
        {
            var listaFormulario = new List<FormularioModelView>();
            FormularioModelView formularioModelView = null;

            foreach (var formulario in lista)
            {
                formularioModelView = new FormularioModelView()
                {
                    IdFormulario = formulario.IdFormulario,
                    DescricaoFormulario = formulario.DescricaoFormulario,
                    NomeFormulario = formulario.NomeFormulario,
                    DataVencimentoFim = formulario.DataVencimentoFim?.ToString("dd/MM/yyyy"),
                    DataVencimentoInicio = formulario.DataVencimentoInicio?.ToString("dd/MM/yyyy"),
                };

                listaFormulario.Add(formularioModelView);
            }

            return listaFormulario;
        }
        
        public static FormularioModelView FormularioModelViewToFormularioDomain(FormularioDomain formulario)
        {
            var formularioModelView = new FormularioModelView();

            if (formulario != null)
            {
                formularioModelView.IdFormulario = formulario.IdFormulario;
                formularioModelView.NomeFormulario = formulario.NomeFormulario;
                formularioModelView.DescricaoFormulario = formulario.DescricaoFormulario;
                formularioModelView.DataVencimentoInicio = formulario.DataVencimentoInicio?.ToString("dd/MM/yyyy");
                formularioModelView.DataVencimentoFim = formulario.DataVencimentoFim?.ToString("dd/MM/yyyy");

                if (formulario.FormularioCampoes != null && formulario.FormularioCampoes.Count > 0)
                {
                    FormularioCampoModelView formularioCampoDomain = null;
                    formularioModelView.FormularioCampos = new List<FormularioCampoModelView>();

                    foreach (var formularioCampo in formulario.FormularioCampoes)
                    {
                        formularioCampoDomain = new FormularioCampoModelView();
                        formularioCampoDomain.IdTipoCampo = formularioCampo.IdTipoCampo;
                        formularioCampoDomain.IdTipoValorCampo = formularioCampo.IdTipoValorCampo;
                        formularioCampoDomain.DescricaoCampo = formularioCampo.DescricaoCampo;
                        formularioCampoDomain.IdFormularioCampo = formularioCampo.IdFormularioCampo;
                        formularioCampoDomain.IdFormulario = formularioCampo.IdFormulario;

                        formularioModelView.FormularioCampos.Add(formularioCampoDomain);

                        if (formularioCampo.ValorCampoes!= null && formularioCampo.ValorCampoes.Count > 0)
                        {
                            formularioCampoDomain.ValorCampos = new List<ValorCampoModelView>();

                            foreach (var valorCampos in formularioCampo.ValorCampoes)
                            {
                                formularioCampoDomain.ValorCampos.Add(new ValorCampoModelView()
                                {
                                    ValorCampo = valorCampos.ValorCampo,
                                    IdFormularioCampo = valorCampos.IdFormularioCampo,
                                    IdValorCampo = valorCampos.IdValorCampo
                                });
                            }
                        }
                    }
                }
            }
            return formularioModelView;
        }
    }
}
