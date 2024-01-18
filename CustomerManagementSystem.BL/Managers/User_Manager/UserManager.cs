using CustomerManagementSystem.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.BL;

public class UserManager : IUserManager
{
    private readonly IUserRepo _userRepo;
    private readonly IConfiguration _configuration;
    private readonly UserManager<IdentityUser> _userManager;
    public UserManager(IUserRepo userRepo, IConfiguration configuration, UserManager<IdentityUser> userManager)
    {
        _userRepo = userRepo;
        _configuration = configuration;
        _userManager = userManager;
    }
    public IEnumerable<UserAddReadDto> GetAllUsers()
    {
        var userFromDB = _userRepo.GetAllUsers();
        return userFromDB.Select(u => new UserAddReadDto
        {
            Name = u.Name,
            UserId = u.Id,
        });
    }
    public UserAddReadDto? GetUserById(string id)
    {
        User? userFromDB = _userRepo.GetUserById(id);
        if(userFromDB == null) { return null; }
        return new UserAddReadDto
        {
            UserId = userFromDB.Id,
            Name = userFromDB.Name,
        };
    }
    private TokenDto GenerateToken(IList<Claim> claimsList)
    {
        string keyString = _configuration.GetValue<string>("SecretKey") ?? string.Empty;
        var keyInBytes = Encoding.ASCII.GetBytes(keyString);
        var key = new SymmetricSecurityKey(keyInBytes);

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var expiry = DateTime.Now.AddMinutes(15);

        var jwt = new JwtSecurityToken(
            expires: expiry,
            claims: claimsList,
            signingCredentials: signingCredentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = tokenHandler.WriteToken(jwt);
        var role = claimsList.First(c => c.Type == ClaimTypes.Role).Value;

        return new TokenDto(TokenResult.Success, tokenString, expiry, role);
    }
    public async Task<TokenDto> Login(LoginDto login)
    {
        IdentityUser? user = await _userManager.FindByNameAsync(login.UserName);
        if (user == null)
        {
            return new TokenDto(TokenResult.Failure);
        }

        bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, login.Password);
        if (!isPasswordCorrect)
        {
            return new TokenDto(TokenResult.UserpasswordError);
        }

        var claimList = await _userManager.GetClaimsAsync(user);
        return GenerateToken(claimList);
    }
    public async Task<RegisterResult> Register(RegisterDto registerDto)
    {
        var newUser = new User
        {
            Name = registerDto.Name,
            
        };

        var creationResult = await _userManager.CreateAsync(newUser, registerDto.Password);
        if (!creationResult.Succeeded)
        {
            return new RegisterResult(false, creationResult.Errors);
        }

        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, newUser.Id),
                new Claim(ClaimTypes.Role, "User")
            };

        await _userManager.AddClaimsAsync(newUser, claims);

        return new RegisterResult(true);
    }
}
