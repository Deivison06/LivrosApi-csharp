using LivrosApi.Data;
using LivrosApi.Dto;
using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LivrosApi.Services.Autor;

public class AutorService: IAutorInterface
{
    private readonly AppdbContext _context;
    
    public AutorService(AppdbContext context)
    {
        _context = context;
    }
    
    // Listagem
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
    

    // Criação
    public async Task<ResponseModel<List<Models.Autor>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
    {
        ResponseModel<List<Models.Autor>> resposta = new ResponseModel<List<Models.Autor>>();
        try
        {
            var autor = new Models.Autor()
            {
                Nome = autorCriacaoDto.Nome,
                Sobrenome = autorCriacaoDto.Sobrenome,
            };

            _context.Add(autor);
            await _context.SaveChangesAsync();
            
            resposta.Dados = await _context.Autors.ToListAsync();
            resposta.Mensagem = "Autor Criado com sucesso!";
            
            return resposta;

        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    // Edição
    public async Task<ResponseModel<List<Models.Autor>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
    {
        ResponseModel<List<Models.Autor>> resposta = new ResponseModel<List<Models.Autor>>();
        try
        {
            var autor = await _context.Autors.FirstOrDefaultAsync(autorBd => autorBd.Id == autorEdicaoDto.Id);
            if (autor == null)
            {
                resposta.Mensagem = "Nenhum autor foi encontrado!";
                return resposta;
            }
            autor.Nome = autorEdicaoDto.Nome;
            autor.Sobrenome = autorEdicaoDto.Sobrenome;
            
            _context.Update(autor);
            await _context.SaveChangesAsync();
            
            resposta.Dados = await _context.Autors.ToListAsync();
            resposta.Mensagem = "Autor Editado com sucesso!";
            
            return resposta;
        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    // Remoção
    public async Task<ResponseModel<List<Models.Autor>>> RemoverAutor(int idAutor)
    {
        ResponseModel<List<Models.Autor>> resposta = new ResponseModel<List<Models.Autor>>();
        try
        {
            var autor = await _context.Autors
                .FirstOrDefaultAsync(autorBd => autorBd.Id == idAutor);
            if (autor == null)
            {
                resposta.Mensagem = "Nenhum autor foi encontrado!";
                return resposta;
            }
            _context.Remove(autor);
            await _context.SaveChangesAsync();
            
            resposta.Dados = await _context.Autors.ToListAsync();
            resposta.Mensagem = "Autor Removido com sucesso!";
            
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