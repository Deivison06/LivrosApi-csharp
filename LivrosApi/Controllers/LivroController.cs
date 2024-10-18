using LivrosApi.Dto;
using LivrosApi.Models;
using LivrosApi.Services.Livro;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : Controller
{
    private readonly ILivroInterface _livroInterface;

    public LivroController(ILivroInterface livroInterface)
    {
        _livroInterface = livroInterface;
    }


    // Listagem

    [HttpGet("ListarLivros")]
    public async Task<ActionResult<ResponseModel<List<Livro>>>> Livroes()
    {
        var livros = await _livroInterface.ListarLivros();
        return Ok(livros);
    }

    [HttpGet("BuscarLivroPorId/{idLivro}")]
    public async Task<ActionResult<ResponseModel<Livro>>> BuscarLivroPorId(int idLivro)
    {
        var livro = await _livroInterface.BuscarLivroPorId(idLivro);
        return Ok(livro);
    }

    [HttpGet("BuscarLivroPorIdLivro/{idAutor}")]
    public async Task<ActionResult<ResponseModel<Livro>>> BuscarLivroPorIdLivro(int idAutor)
    {
        var livro = await _livroInterface.BuscarLivroPorIdAutor(idAutor);
        return Ok(livro);
    }


    // Criação

    [HttpPost("CriarLivro")]
    public async Task<ActionResult<ResponseModel<Livro>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
    {
        var livros = await _livroInterface.CriarLivro(livroCriacaoDto);
        return Ok(livros);
    }


    // Edição

    [HttpPut("AtualizarLivro")]
    public async Task<ActionResult<ResponseModel<List<Livro>>>> EditarLivro(LivroEdicaoDto livroEditDto)
    {
        var livros = await _livroInterface.EditarLivro(livroEditDto);
        return Ok(livros);
    }


    // Remoção

    [HttpDelete("ExcluirLivro")]
    public async Task<ActionResult<ResponseModel<List<Livro>>>> RemoverAutor(int idLivro)
    {
        var livros = await _livroInterface.RemoverLivro(idLivro);
        return Ok(livros);
    }
}