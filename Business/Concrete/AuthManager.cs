using Business.Abstract;
using Business.ValidationRules.FluentValidation;


using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public string MailContent = "";
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var checkUser = _userService.Get(u => u.UserName == userForLoginDto.UserName);
            if (checkUser.Data == null)
            {
                return new ErrorDataResult<User>("User not found");
            }
            if (!HashingHelper.VerifyPasswordHash(
                userForLoginDto.Password,
                checkUser.Data.PasswordHash,
                checkUser.Data.PasswordSalt
                ))
            {
                return new ErrorDataResult<User>("Hatalı şifre girdiniz!");
            }
            return new SuccessDataResult<User>(checkUser.Data, "Kullacını girişi başarılı.");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var check = this.UserExists(userForRegisterDto.UserName);
            if (check.Success)
            {
                return new ErrorDataResult<User>("Bu kullanıcı adı sistemde var!");
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User()
            {
             
                UserName = userForRegisterDto.UserName,
                Email = userForRegisterDto.Email,
                Status = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            _userService.Add(user);

            return new SuccessDataResult<User>(user, "Kayıt işlemi başarılı.");
        }

        public IResult UserExists(string userName)
        {
            if (_userService.Get(u => u.UserName == userName).Data == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu.");
        }
    }
}
