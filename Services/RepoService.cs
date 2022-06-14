using Microsoft.EntityFrameworkCore;
using s22686_kol2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s22686_kol2.Services
{
    public class RepoService : IRepoService
    {
        private readonly RepositoryContext _repository;
        public RepoService(RepositoryContext repository)
        {
            _repository = repository;
        }
        public Task DeleteMusician(int IdMusician)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Album> GetAlbum(int IdAlbum)
        {
            return _repository.Albums
                .Where(e => e.IdAlbum == IdAlbum)
                .Include(e => e.Tracks);
        }

        public IQueryable<Musician> GetMusician(int IdMusician)
        {
            return _repository.Musicians
                .Where(e => e.IdMusician == IdMusician);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
    }
}
