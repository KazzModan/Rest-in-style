namespace R.I.S.BLL.Auth;

public class JwtOptions
{
    public string SecretKey { get; set; }
    public int ExpiresHours { get; set; }
}