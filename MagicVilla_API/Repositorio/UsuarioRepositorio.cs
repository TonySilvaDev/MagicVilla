using AutoMapper;
using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla_API.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _db;
        private string secretKey;
        private readonly UserManager<UsuarioAplicacion> _userManager;
        private readonly IMapper _mapper;

        public UsuarioRepositorio(ApplicationDbContext db, IConfiguration configuration, UserManager<UsuarioAplicacion> userManager, IMapper mapper)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _userManager = userManager;
            _mapper = mapper;
        }

        public bool IsUsuarioUnico(string userName)
        {
            var usuario = _db.UsuariosAplicacion.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());

            if (usuario == null)
            {
                return true;
            }

            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var usuario = _db.UsuariosAplicacion.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            bool isValido = await _userManager.CheckPasswordAsync(usuario, loginRequestDto.Password);

            if (usuario == null || !isValido)
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    Usuario = null
                };
            }

            //Si usuaio existe, generamos el JW Token
            var roles = await _userManager.GetRolesAsync(usuario);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDto loginResponseDto = new()
            {
                Token = tokenHandler.WriteToken(token),
                Usuario = _mapper.Map<UsuarioDto>(usuario),
                Rol = roles.FirstOrDefault()
            };

            return loginResponseDto;
        }

        public async Task<Usuario> Registrar(RegistroRequestDto registroRequestDto)
        {
            Usuario usuario = new()
            {
                UserName = registroRequestDto.UserName,
                Password = registroRequestDto.Password,
                Nombres = registroRequestDto.Nombres,
                Rol = registroRequestDto.Rol
            };

            await _db.Usuarios.AddAsync(usuario);
            await _db.SaveChangesAsync();

            // Quitar password para no regresarlo
            usuario.Password = "";

            return usuario;
        }
    }
}
