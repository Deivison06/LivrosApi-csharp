using LivrosApi.Models;

namespace LivrosApi.Services.Autor;

public interface IAutorInterface
{
    Task<ResponseModel<List<Models.Autor>>> ListarAutors();
    Task<ResponseModel<Models.Autor>> BuscarAutorPorId(int idAutor);
    Task<ResponseModel<Models.Autor>> BuscarAutorPorIdLivro(int idLivro);
}