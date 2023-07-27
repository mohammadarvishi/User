using User.Domain.ViewModels;

namespace User.API.Token
{
    public interface ICreateToken
    {
        Task<TokenViewModel> Token(string userid);
    }
}
