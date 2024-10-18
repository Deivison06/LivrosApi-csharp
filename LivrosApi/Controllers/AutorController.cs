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
    
}