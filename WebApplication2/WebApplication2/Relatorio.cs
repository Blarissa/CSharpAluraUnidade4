﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web
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
            {
                await context.Response.WriteAsync($"{livro.Codigo}{livro.Nome}{livro.Preco}\r\n");
            }
        }
    }
}