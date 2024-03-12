using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private IEmpleado _empleadoRepository;

        public EmpleadoController(IEmpleado empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }


        [HttpGet]
        public IActionResult Get(string nombre) 
        {
            var result = _empleadoRepository.GetEmpleadoByNombre(nombre);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Empleado empleado)
        {
            empleado.Password = empleado.Password.GetHashCode().ToString();// GetHash(empleado.Password);
            int result = _empleadoRepository.CreateEmpleado(empleado);

            if(result <= 0)
            {
                return BadRequest("Failed");
            }

            return Ok(empleado);
             
        }

        private string GetHash(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding= new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for(int i= 0; stream.Length > 0; i++)
            {
                sb.AppendFormat("{0:X2", stream[i]);
                    
            }
            return sb.ToString();
        }

    }
}
