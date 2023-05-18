//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Diagnostics;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace TheWhaddonShowAPI.Controllers;


//[Route("api/[controller]")]
//[ApiController]
//[ApiVersionNeutral]
//public class AuthenticationController : ControllerBase
//{
    
//    public record AuthenticationData(string? Username, string? Password);
//    public record UserData(int UserId, string Username);

//    private IConfiguration _config;
//    /// <summary>
//    /// Constructor fro AuthenticationController
//    /// </summary>
//    public AuthenticationController(IConfiguration config)
//    {
//        _config = config;
//    }


//    //api/Authentication/token
//    [HttpPost("token")]
//    public ActionResult<string> Authenticate([FromBody] AuthenticationData data)
//    {
//        var user = ValidateCredentials(data);

//        if (user is null)
//        {
//            return Unauthorized();
//        }
//        var token = GenerateToken(user);

//        return Ok(token);

//    }

//  private string GenerateToken(UserData user)
//    {
//        var tokenHandler = new JwtSecurityTokenHandler();

//        var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetValue<string>("Authentication:SecretKey") ?? ""));

//        List<Claim> claims = new List<Claim>();
//        claims.Add(new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()));
//        claims.Add(new(JwtRegisteredClaimNames.UniqueName, user.Username.ToString()));

//        var tokenDescriptor = new SecurityTokenDescriptor
//        {
//            Issuer = _config.GetValue<string>("Authentication:Issuer"),
//            Audience = _config.GetValue<string>("Authentication:Audience"),
//            Subject = new ClaimsIdentity(claims),
//            NotBefore = DateTime.UtcNow,
//            Expires = DateTime.UtcNow.AddMinutes(1),
//            SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
//        };
        
//        var token = tokenHandler.CreateToken(tokenDescriptor);
       
//        return tokenHandler.WriteToken(token);
//    }

////-----------------TODO REPLACE WITH AUTHENTICATON PROVIDER
//    private UserData? ValidateCredentials(AuthenticationData data)
//    {
//        ///TODO - replace with Differetn authorization providedr
//        if (CompareValues(data.Username,"mcarter") &&
//           CompareValues(data.Password, "1234"))
//        {
//            return new UserData(1, data.Username);
//        }

//        return null;

//    }

//    private bool CompareValues(string? actual, string? expected)
//    {
//        if (actual is not null)
//        {
//            if (actual.Equals(expected))
//            {
//                return true;
//            }
//        }
//        return false;
//    }
////-------------------------------

   


  
//}
