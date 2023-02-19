using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Relatorio
    {
        private readonly Catalogo catalogo;

        public Relatorio(Catalogo catalogo)
        {
            this.catalogo = catalogo;
        }

        public async Task Imprimir(HttpContext context)
        {
            foreach (var livro in catalogo.GetLivros())
            
                await context.Response.WriteAsync(
                    $"{livro.Codigo,-10} " +
                    $"{livro.Nome,-40} " +
                    $"{livro.Preco,10:C}\r\n");
            
        }
    }
}
