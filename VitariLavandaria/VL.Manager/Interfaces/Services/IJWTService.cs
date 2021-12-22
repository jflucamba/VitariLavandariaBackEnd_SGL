using VL.Core.Domain;

namespace VL.Manager.Interfaces.Services
{
    public interface IJWTService
    {
        string GerarToken(Usuario usuario);
    }
}