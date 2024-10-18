using LivrosApi.Dto;
using LivrosApi.Models;
using LivrosApi.Services.Autor;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorController : Controller
{
    private readonly IAutorInterface _autorInterface;

    public AutorController(IAutorInterface autorInterface)
    {
        _autorInterface = autorInterface;
    }


    // Listagem

    [HttpGet("ListarAutores")]
    public async Task<ActionResult<ResponseModel<List<Autor>>>> ListarAutores()
    {
        var autores = await _autorInterface.ListarAutors();
        return Ok(autores);
    }

    [HttpGet("BuscarAutorPorId/{idAutor}")]
    public async Task<ActionResult<ResponseModel<Autor>>> BuscarAutorPorId(int idAutor)
    {
        var autor = await _autorInterface.BuscarAutorPorId(idAutor);
        return Ok(autor);
    }

    [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
    public async Task<ActionResult<ResponseModel<Autor>>> BuscarAutorPorIdLivro(int idLivro)
    {
        var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
        return Ok(autor);
    }


    // Criação

    [HttpPost("CriarAutor")]
    public async Task<ActionResult<ResponseModel<Autor>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
    {
        var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
        return Ok(autores);
    }


    // Edição

    [HttpPut("AtualizarAutor")]
    public async Task<ActionResult<ResponseModel<List<Autor>>>> EditarAutor(AutorEdicaoDto autorEditDto)
    {
        var autores = await _autorInterface.EditarAutor(autorEditDto);
        return Ok(autores);
    }


    // Remoção

    [HttpDelete("ExcluirAutor/{idAutor}")]
    public async Task<ActionResult<ResponseModel<List<Autor>>>> RemoverAutor(int idAutor)
    {
        var autores = await _autorInterface.RemoverAutor(idAutor);
        return Ok(autores);
    }
}