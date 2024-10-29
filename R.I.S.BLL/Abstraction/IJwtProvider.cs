using R.I.S.DAL.Models;

namespace R.I.S.BLL.Abstraction;

public interface IJwtProvider
{
    string GenerateToken(User user);

}