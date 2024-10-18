using LivrosApi.Data;
using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Services.Autor;

public class AutorService: IAutorInterface
{
    private readonly AppdbContext _context;
    
    public AutorService(AppdbContext context)
    {
        _context = context;
    }
    
    public async Task<ResponseModel<List<Models.Autor>>> ListarAutors()
    {
        ResponseModel<List<Models.Autor>> resposta = new ResponseModel<List<Models.Autor>>();
        try
        {
            var autores = await _context.Autors.ToListAsync();
            
            resposta.Dados = autores;
            resposta.Mensagem = "Autors Coletados com sucesso!";
            return resposta;

        }
        catch (Exception e)
        {
           resposta.Mensagem = e.Message;
           resposta.Status = false;
           return resposta;
        }
    }
    public async Task<ResponseModel<Models.Autor>> BuscarAutorPorId(int idAutor)
    {
        ResponseModel<Models.Autor> resposta = new ResponseModel<Models.Autor>();
        try
        {
            var autor = await _context.Autors.FirstOrDefaultAsync(autorBd => autorBd.Id == idAutor);
            if (autor == null)
            {
                resposta.Mensagem = "Nenhum autor foi encontrado!";
                return resposta;
            }
            resposta.Dados = autor;
            resposta.Mensagem = "Autor Localizado com sucesso!";
            return resposta;
        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }
    public async Task<ResponseModel<Models.Autor>> BuscarAutorPorIdLivro(int idLivro)
    {
        ResponseModel<Models.Autor> resposta = new ResponseModel<Models.Autor>();
        try
        {
            var livro = await _context.Livros
                .Include(a => a.Autor)
                .FirstOrDefaultAsync(livroBd => livroBd.Id == idLivro);

            if (livro == null)
            {
                resposta.Mensagem = "Nenhum Registro foi encontrado!";
            }
            resposta.Dados = livro.Autor;
            resposta.Mensagem = "Autor Localizado com sucesso!";
            return resposta;
        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }
}