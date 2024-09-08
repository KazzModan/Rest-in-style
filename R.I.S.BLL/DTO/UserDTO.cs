using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.I.S.BLL.DTO
{
    public class UserDTO
    {
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
