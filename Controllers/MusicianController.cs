using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using s22686_kol2.DTOs;
using s22686_kol2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace s22686_kol2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IRepoService _service;

        public MusicianController(IRepoService service)
        {
            _service = service;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMusician (int IdMusician)
        {
            if (!ModelState.IsValid)
                return BadRequest("Niepoprawne ciało żądania!");
            if (await _service.GetMusician(IdMusician).FirstOrDefaultAsync() is null)
                return NotFound("Nie znaleziono muzyka o podanym ID");
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await _service.DeleteMusician(IdMusician);
                    await _service.SaveChangesAsync();
                    scope.Complete();
                }
                catch (Exception)
                {
                    return Problem("Nieoczekiwany błąd serwera");
                }

            }
            await _service.SaveChangesAsync();
            return Ok();
        }
    }
}
