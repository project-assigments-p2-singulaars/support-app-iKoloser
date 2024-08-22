namespace SupportAppV3.Repository;
using SupportAppV3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


    public interface IUsuarioTareaRepository
    {
        Task<IEnumerable<UsuarioTarea>> GetAllAsync();
        Task<UsuarioTarea> GetByIdAsync(int usuarioId, int tareaId, int rolId);
        Task AddAsync(UsuarioTarea usuarioTarea);
        void Update(UsuarioTarea usuarioTarea);
        void Delete(UsuarioTarea usuarioTarea);
    }
