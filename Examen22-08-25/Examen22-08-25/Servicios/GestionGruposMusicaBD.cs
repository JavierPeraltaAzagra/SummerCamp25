using Examen22_08_25.Contexto;
using Examen22_08_25.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen22_08_25.Servicios
{
    public class GestionGruposMusicaBD : IGestionGruposMusica
    {
        private readonly AppDbContext contexto;

        public GestionGruposMusicaBD(AppDbContext contexto)
        {
            this.contexto = contexto;
        }

        public void ActualizarGrupo(GrupoMusica grupo)
        {
            contexto.GruposMusica.Update(grupo);
        }

        public void Agregar(GrupoMusica grupo)
        {
            contexto.GruposMusica.Add(grupo);
        }

        public void EliminarGrupo(GrupoMusica grupo)
        {
            contexto.GruposMusica.Remove(grupo);
        }

        public async Task<bool> GuardarCambios()
        {
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<GrupoMusica?> ObtenerPorId(int id)
        {
            return await contexto.GruposMusica.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<GrupoMusica>> ObtenerTodos()
        {
            return await contexto.GruposMusica.ToListAsync();
        }

        public async Task<(List<GrupoMusica> grupos, int totalRegistros)> ObtenerTodosFiltrado(string? genero, string? nombre, int numeroPagina, int tamañoPagina)
        {
            var consulta = contexto.GruposMusica.AsQueryable();

            if (!string.IsNullOrEmpty(genero))
            {
                genero = genero.Trim();
                consulta = consulta.Where(g => g.Genero == genero);
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                nombre = nombre.Trim();
                consulta = consulta.Where(g => g.Nombre.Contains(nombre));
            }

            var totalRegistros = await consulta.CountAsync();

            var grupos = await consulta
                .OrderBy(g => g.Nombre)
                .Skip((numeroPagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .ToListAsync();

            return (grupos, totalRegistros);
        }
    }
}
