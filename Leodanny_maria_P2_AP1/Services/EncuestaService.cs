using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Leodanny_maria_P2_AP1.Models;
using Leodanny_maria_P2_AP1.Context;
using static Azure.Core.HttpHeader;

namespace Leodanny_maria_P2_AP1.Services
{
    public class EncuestasService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<List<Encuestas>> Listar(Expression<Func<Encuestas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Encuesta
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var eliminando = await contexto.Encuesta
                .Where(c => c.EncuestaId == id)
                .ExecuteDeleteAsync();
            return eliminando > 0;

        }

        public async Task<bool> Existe(int articuloid)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Encuesta.AnyAsync(c => c.EncuestaId == articuloid);

        }

        public async Task<bool> Insertar(Encuestas encuesta)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Encuesta.Add(encuesta);
            return await contexto.SaveChangesAsync() > 0;

        }

        public async Task<bool> Modificar(Encuestas encuesta)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Encuesta.Update(encuesta);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Encuestas encuesta)
        {
            if (!await Existe(encuesta.EncuestaId))
                return await Insertar(encuesta);
            else
                return await Modificar(encuesta);
        }

        public async Task<Encuestas?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Encuesta
                .AsNoTracking()
                .Include(c => c.encuestasDetalle)
                .FirstOrDefaultAsync(c => c.EncuestaId == id);
        }

        public async Task AfectarMonto(EncuestasDetalle detalle, bool Suma)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var encuesta = await contexto.Encuesta
                .FirstOrDefaultAsync(e => e.EncuestaId == detalle.EncuestaId);

            if (encuesta != null)
            {
                if (Suma)
                {
                    encuesta.Monto -= detalle.Monto;
                }
                else
                {
                    encuesta.Monto += detalle.Monto;
                }

                await contexto.SaveChangesAsync();
            }
        }
    }
}