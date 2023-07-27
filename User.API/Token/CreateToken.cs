


using User.Domain.ViewModels;
using static User.API.Protos.Token;

namespace User.API.Token
{
    public class CreateToken : ICreateToken
    {
        private readonly TokenClient _tokenClient;
        public CreateToken(TokenClient tokenClient)
        {
            this._tokenClient = tokenClient;
        }
        public async Task<TokenViewModel> Token(string userid)
        {
            var token = new TokenViewModel();
            try
            {
                var TokenResult = await _tokenClient.CreateTokenAsync(
                     new Protos.TokenRequest { Userid = userid });

                token.Token = TokenResult.Token;

            }
            catch (Exception ex)
            {
                token.Token = ex.Message.ToString();
                return token;
            }

            return token;
        }
    }
}
