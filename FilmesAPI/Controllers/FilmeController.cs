using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody]Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);

            //mostra status da requisição e onde recurso foi criado
            //
            //created action está falando qual é o caminho, qual é a ação que criou este recurso
            //
            //Parâmetros
            //
            //nome da action => nameof(RecuperaFilmesPorId)
            //valor da rota  => new { id = filme.Id}
            //recurso        => filme
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { id = filme.Id}, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(filmes);
        }
        
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme =  filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
                return Ok(filme);

            return NotFound();        
        }
    }
}
