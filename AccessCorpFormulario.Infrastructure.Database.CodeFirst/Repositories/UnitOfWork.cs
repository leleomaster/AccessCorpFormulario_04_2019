using AccessCorpFormulario.Infrastructure.Database.CodeFirst.Interfaces;
using System;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AccessCorpContext _contexto = null;

        private IRepositorioBase<FormularioDomain> _formularioDomainRepositorio { get; set; }
        private IRepositorioBase<FormularioCampoDomain> _formularioCampoDomain { get; set; }
        private IRepositorioBase<ValorCampoDomain> _valorCampoDomain { get; set; }

        public UnitOfWork()
        {
            _contexto = new AccessCorpContext();
        }

        public async void CommitAsync()
        {
            await _contexto.SaveChangesAsync();
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IRepositorioBase<FormularioDomain> FormularioRepositorio
        {
            get
            {
                if (_formularioDomainRepositorio == null)
                {
                    _formularioDomainRepositorio = new RepositorioBase<FormularioDomain>(_contexto);
                }
                return _formularioDomainRepositorio;
            }
        }

        public IRepositorioBase<FormularioCampoDomain> FormularioCampoRepositorio
        {
            get
            {
                if (_formularioCampoDomain == null)
                {
                    _formularioCampoDomain = new RepositorioBase<FormularioCampoDomain>(_contexto);
                }
                return _formularioCampoDomain;
            }
        }

        public IRepositorioBase<ValorCampoDomain> ValorCampoRepositorio
        {
            get
            {
                if (_valorCampoDomain == null)
                {
                    _valorCampoDomain = new RepositorioBase<ValorCampoDomain>(_contexto);
                }
                return _valorCampoDomain;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
