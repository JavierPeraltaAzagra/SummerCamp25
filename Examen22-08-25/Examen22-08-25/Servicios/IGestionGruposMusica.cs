using Examen22_08_25.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examen22_08_25.Servicios
{
    public interface IGestionGruposMusica
    {
        Task<List<GrupoMusica>> ObtenerTodos();
        Task<(List<GrupoMusica> grupos, int totalRegistros)> ObtenerTodosFiltrado(string? genero, string? nombre, int numeroPagina, int tamañoPagina);
        Task<GrupoMusica?> ObtenerPorId(int id);
        Task<bool> GuardarCambios();
        void Agregar(GrupoMusica grupo);
        void ActualizarGrupo(GrupoMusica grupo);
        void EliminarGrupo(GrupoMusica grupo);
    }
}
