using LivrosApi.Dto.Vinculo;
using LivrosApi.Models;

namespace LivrosApi.Dto;

public class LivroCriacaoDto
{
    public string Titulo { get; set; }
    public AutorVinculoDto Autor { get; set; }
}