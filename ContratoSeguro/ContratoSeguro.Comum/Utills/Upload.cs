using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Comum.Utills
{
    public static class Upload
    {
        public static string Local(IFormFile arquivo)
        {
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(arquivo.FileName);

            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\upload", nomeArquivo);

            using var streamArquivo = new FileStream(caminhoArquivo, FileMode.Create);

            arquivo.CopyTo(streamArquivo);

            return "http://192.168.0.76:5001/upload/" + nomeArquivo;
        }

        public static string Imagem(IFormFile arquivo)
        {
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(arquivo.FileName);

            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", nomeArquivo);

            using var streamArquivo = new FileStream(caminhoArquivo, FileMode.Create);

            arquivo.CopyTo(streamArquivo);

            return "http://192.168.0.76:5001/images/" + nomeArquivo;
        }
    }
}
