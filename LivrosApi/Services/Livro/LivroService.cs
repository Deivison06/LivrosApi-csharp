using LivrosApi.Data;
using LivrosApi.Dto;
using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Services.Livro;

public class LivroService: ILivroInterface
{
    
    private readonly AppdbContext _context;

    public LivroService(AppdbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel<List<Models.Livro>>> ListarLivros()
    {
        ResponseModel<List<Models.Livro>> resposta = new ResponseModel<List<Models.Livro>>();
        try
        {
            var livros = await _context.Livros.Include(a => a.Autor).ToListAsync();
            
            resposta.Dados = livros;
            resposta.Mensagem = "Livros Coletados com sucesso!";
            return resposta;

        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<Models.Livro>> BuscarLivroPorId(int idLivro)
    {
        ResponseModel<Models.Livro> resposta = new ResponseModel<Models.Livro>();
        try
        {

            var livro = await _context.Livros.Include(a => a.Autor)
                .FirstOrDefaultAsync(livroBd => livroBd.Id == idLivro);

            if (livro == null)
            {
                resposta.Mensagem = "Nenhum registro localizado!";
                return resposta;
            }

            resposta.Dados = livro;
            resposta.Mensagem = "Livro Localizado com Sucesso!";

            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<Models.Livro>>> BuscarLivroPorIdAutor(int idAutor)
    {
        ResponseModel<List<Models.Livro>> resposta = new ResponseModel<List<Models.Livro>>();
        try
        {
            var livro = await _context.Livros.
                Include(a => a.Autor)
                .Where(livroDb => livroDb.Id == idAutor)
                .ToListAsync();
            
            if (livro == null)
            {
                resposta.Mensagem = "Nenhum livro foi encontrado!";
                return resposta;
            }
            
            resposta.Dados = livro;
            resposta.Mensagem = "Livros Localizado com sucesso!";
            return resposta;
        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<Models.Livro>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
    {
        ResponseModel<List<Models.Livro>> resposta = new ResponseModel<List<Models.Livro>>();
        try
        {
            var autor = await _context.Autors
                .FirstOrDefaultAsync(autorBd => autorBd.Id == livroCriacaoDto.Autor.Id);
            
            if (autor == null)
            {
                resposta.Mensagem = "Nenhum registro de autor localizado!";
                return resposta;
            }
            
            var livro = new Models.Livro()
            {
                Titulo = livroCriacaoDto.Titulo,
                Autor = autor,
            };

            _context.Add(livro);
            await _context.SaveChangesAsync();
            
            resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
            
            return resposta;

        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<Models.Livro>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
    {
        ResponseModel<List<Models.Livro>> resposta = new ResponseModel<List<Models.Livro>>();
        try
        {
            var livro = await _context.Livros
                .Include(a => a.Autor)
                .FirstOrDefaultAsync(livroBd => livroBd.Id == livroEdicaoDto.Id);

            var autor = await _context.Autors
                .FirstOrDefaultAsync(autorBd => autorBd.Id == livroEdicaoDto.Autor.Id);
            

            if (autor == null)
            {
                resposta.Mensagem = "Nenhum registro de autor localizado!";
                return resposta;
            }

            if (livro == null)
            {
                resposta.Mensagem = "Nenhum registro de livro localizado!";
                return resposta;
            }
            
            livro.Titulo = livroEdicaoDto.Titulo;
            livro.Autor = autor;
            
            _context.Update(livro);
            await _context.SaveChangesAsync();
            
            resposta.Dados = await _context.Livros.ToListAsync();

            return resposta;
        }
        catch (Exception e)
        {
            resposta.Mensagem = e.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<Models.Livro>>> RemoverLivro(int idLivro)
    {
        ResponseModel<List<Models.Livro>> resposta = new ResponseModel<List<Models.Livro>>();
        try
        {
            var livro = await _context.Livros.Include(a => a.Autor)
                .FirstOrDefaultAsync(livroBd => livroBd.Id == idLivro);
            
            if (livro == null)
            {
                resposta.Mensagem = "Nenhum livro foi encontrado!";
                return resposta;
            }
            _context.Remove(livro);
            await _context.SaveChangesAsync();
            
            resposta.Dados = await _context.Livros.ToListAsync();
            resposta.Mensagem = "Livro Removido com sucesso!";
            
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