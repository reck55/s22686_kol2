using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using s22686_kol2.Models;

namespace s22686_kol2.Services
{
    public interface IRepoService
    {
        IQueryable<Album> GetAlbum(int IdAlbum);
        Task DeleteMusician(int IdMusician);
        IQueryable<Musician> GetMusician(int IdMusician);
        Task SaveChangesAsync();
    }
}
