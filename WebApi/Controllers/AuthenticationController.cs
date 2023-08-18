using AutoMapper;
using Application.DTOs.Requests;
using Application.Interfaces;
using Domain.Entities;
using Infra.Data.Efcore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISignup _signup;
        public AuthenticationController(ISignup signup) {
            _signup = signup;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] UserSignupDTO dto)
        {
            
            var result = await _signup.SignupAsync(dto);

            return Ok(result);
        }

       
    }
}
