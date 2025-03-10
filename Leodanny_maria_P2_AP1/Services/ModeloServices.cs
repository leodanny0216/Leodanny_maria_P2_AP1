using Leodanny_maria_P2_AP1.Models;
using System.Linq.Expressions;

namespace Leodanny_maria_P2_AP1.Services
{
    public class ModeloServices
    {
        public async Task<bool> Guardar(Modelo modelo)
        {
            return true;
        }

        public async Task<bool> Existe(int Id)
        {
            return true;
        }

        public async Task<bool> Insertar(Modelo modelo)
        {
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            return true;
        }

        public async Task<bool> Modificar(Modelo modelo)
        {
            return true;
        }

        public async Task<Modelo?> Buscar(int id)
        {
            return new Modelo();
        }

        public async Task<List<Modelo>> Listar(Expression<Func<Modelo, bool>> criterio)
        {
            return new List<Modelo>();
        }

    }
}
