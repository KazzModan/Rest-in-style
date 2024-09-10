using R.I.S.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.BLL.Services.Abstraction
{
    public interface IUserService
    {
        Task<ICollection<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(Guid id);
        Task DeleteUser(Guid id);
        Task AddUser(UserDTO User);
        Task UpdateUser(UserDTO User);
    }
}
