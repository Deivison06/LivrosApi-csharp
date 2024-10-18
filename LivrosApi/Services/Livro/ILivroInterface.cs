using LivrosApi.Dto;
using LivrosApi.Models;

namespace LivrosApi.Services.Livro;

public interface ILivroInterface
{
    // EndPoint de Listagem de autores
    Task<ResponseModel<List<Models.Livro>>> ListarLivros();
    Task<ResponseModel<Models.Livro>> BuscarLivroPorId(int idLivro);
    Task<ResponseModel<List<Models.Livro>>> BuscarLivroPorIdAutor(int idAutor);
    
    // Endpoint de Criação de editor
    Task<ResponseModel<List<Models.Livro>>> CriarLivro(LivroCriacaoDto autorCriacaoDto);
    
    // Endpoint de Edição de editor
    Task<ResponseModel<List<Models.Livro>>> EditarLivro(LivroEdicaoDto autorEdicaoDto);
    
    // Endpoint de remoção de editor
    Task<ResponseModel<List<Models.Livro>>> RemoverLivro(int idLivro);
}