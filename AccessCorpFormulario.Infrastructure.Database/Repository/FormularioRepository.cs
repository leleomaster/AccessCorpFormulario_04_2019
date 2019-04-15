using AccessCorpFormulario.Infrastructure.Database.CodeFirst;
using AccessCorpFormulario.Infrastructure.Database.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Infrastructure.Database.Repository
{
    public class FormularioRepository : BaseRepository, IFormularioRepository
    {
     private readonly  AccessCorpContext _db;

        public FormularioRepository(AccessCorpContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
           _db.FormularioDomain.
        }

        public async Task<FormularioDomain> GetById(int id)
        {
            FormularioDomain formualrio;

            using (var db = GetConnection())
            {
                try
                {
                    DynamicParameters p = new DynamicParameters();

                    p.AddDynamicParams(new
                    {
                        idFormulario = id
                    });

                    formualrio = new FormularioDomain();

                    Func<FormularioDomain, FormularioCampoDomain, TipoCampoDomain, TipoValorCampoDomain, ValorCampoDomain, FormularioDomain> mapper = ((f, fc, tc, tvc, vc) =>
                    {

                        if(vc == null) { vc = new ValorCampoDomain(); }



                        if(fc == null) { fc = new FormularioCampoDomain(); }

                        //fc.Add(tc);
                        //fc.TipoValorCampo = tvc;

                        //if (fc.ValorCampos == null || fc.ValorCampos.Count == 0)
                        //{
                        //    fc.ValorCampos = new List<ValorCampoDomain>();
                        //}
                        //fc.ValorCampos.Add(vc);

                        if (f.FormularioCampos == null || f.FormularioCampos.Count == 0)
                        {
                            f.FormularioCampos = new List<FormularioCampoDomain>();
                        }
                        f.FormularioCampos.Add(fc);

                        return f;
                    });

                    var query = db.Query<FormularioDomain, FormularioCampoDomain, TipoCampoDomain, TipoValorCampoDomain, ValorCampoDomain, FormularioDomain>
                        ("sp_get_formulario_by_id", mapper,param: p, commandType: CommandType.StoredProcedure, splitOn: "DescricaoCampo,NomeTipoCampo,NomeTipoValorCampo,ValorCampo");

                    formualrio = query.FirstOrDefault();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return formualrio;
        }

        public int Insert(FormularioDomain t)
        {
            using (var db = GetConnection())
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@IdFormulario", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(
                    new
                    {
                        NomeFormulario = t.NomeFormulario,
                        DataVencimentoInicio = t.DataVencimentoInicio,
                        DataVencimentoFim = t.DataVencimentoFim,
                        DescricaoFormulario = t.DescricaoFormulario
                    });

                int resultado = db.Execute("sp_formulario_Inserir", p, commandType: CommandType.StoredProcedure);
                if (resultado != 0)
                {
                    return p.Get<int>("@IdFormulario");
                }
                return 0;
            }
        }

        public async Task<IList<FormularioDomain>> List()
        {
            using (var db = GetConnection())
            {
                var lista = await db.QueryAsync<FormularioDomain>("sp_get_all_formulario", commandType: CommandType.StoredProcedure);

                return lista.ToList();
            }
        }

        public void Update(FormularioDomain t)
        {
            throw new NotImplementedException();
        }



    }
}
