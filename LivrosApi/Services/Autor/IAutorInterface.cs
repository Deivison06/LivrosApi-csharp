using LivrosApi.Dto;
using LivrosApi.Models;

namespace LivrosApi.Services.Autor;

public interface IAutorInterface
{
    // EndPoint de Listagem de autores
    Task<ResponseModel<List<Models.Autor>>> ListarAutors();
    Task<ResponseModel<Models.Autor>> BuscarAutorPorId(int idAutor);
    Task<ResponseModel<Models.Autor>> BuscarAutorPorIdLivro(int idLivro);
    
    // Endpoint de Criação de editor
    Task<ResponseModel<List<Models.Autor>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
    
    // Endpoint de Edição de editor
    Task<ResponseModel<List<Models.Autor>>> EditarAutor(AutorEdicaoDto autorEdicaoDto);
    
    // Endpoint de remoção de editor
    Task<ResponseModel<List<Models.Autor>>> RemoverAutor(int idAutor);
    
}