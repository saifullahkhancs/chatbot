using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;


public class JwtTokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly IUserRoleRepository _userRoleRepository;  // Add this
    private readonly IRoleRepository _roleRepository;          // Add this

    public JwtTokenService(IConfiguration config, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository)
    {
        _config = config;
        _userRoleRepository = userRoleRepository;
        _roleRepository = roleRepository;
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            // new Claim(ClaimTypes.Role, user.UserRoles.FirstOrDefault()?.Role.Name ?? "User")
        };

        var userRoles = _userRoleRepository.GetByUserId(user.Id).ToList();

        if (userRoles != null && userRoles.Any())
        {
            foreach (var userRole in userRoles)
            {
                var role = _roleRepository.GetByIdAsync(userRole.RoleId).Result;
                if (role != null)
                {
                    // Add each role as a separate claim
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    Console.WriteLine($"Added role: {role.Name}"); // For debugging
                }
            }
        }
        else
        {
            Console.WriteLine("No roles found for user");
            // Add default role if needed
            claims.Add(new Claim(ClaimTypes.Role, "User"));
        }


        // 🔥 FIX: Add role claims
        // var userRoles = _userRoleRepository.GetByUserId(user.Id).ToList();
        // foreach (var userRole in userRoles)
        // {
        //     var role = _roleRepository.GetByIdAsync(userRole.RoleId).Result;
        //     if (role != null)
        //     {
        //         claims.Add(new Claim(ClaimTypes.Role, role.Name));
        //     }
        // }

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
