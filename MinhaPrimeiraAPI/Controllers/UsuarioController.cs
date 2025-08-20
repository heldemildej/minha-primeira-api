using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Controllers.Model;
using System.Collections.Generic;          // Traz List<T>, IEnumerable<T>
using System.Linq;                         // Traz FirstOrDefault, Max (usados nas buscas e no cálculo de Id)

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinhaPrimeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Lista estática simulando um "banco de dados em memória"
        private static List<UsuarioModel> usuarios = new List<UsuarioModel>()
        {
            new UsuarioModel{Id = 1, Nome = "Heldemilde João", Email = "heldemildes@gmail.com"}
        };

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioModel>> Get()
        {
            return Ok(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<UsuarioModel>> Get(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if(usuario == null)
            {
                return NotFound(); // Retorna 404 se não encontrar o usuário
            }

            return Ok(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioModel usuario)
        {
            // Gera ID automaticamente
            usuario.Id = usuarios.Count() > 0 ? usuarios.Max(u => u.Id) + 1 : 1;

            usuarios.Add(usuario);
            return CreatedAtAction(nameof(Get), new {id = usuario.Id}, usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UsuarioModel usuarioAtualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                return NotFound();

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;

            return NoContent(); // 204 = atualizado com sucesso
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
                return NotFound();

            usuarios.Remove(usuario);
            return NoContent();
        }
    }
}
