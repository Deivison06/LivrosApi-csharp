using LivrosApi.Dto.Vinculo;
using LivrosApi.Models;

namespace LivrosApi.Dto;

public partial class LivroEdicaoDto
{
    public int Id { get; set; }
    
    public string Titulo { get; set; }

    public AutorVinculoDto Autor { get; set; }
}