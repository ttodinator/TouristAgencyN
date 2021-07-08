using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Kontroler koji sluzi za registraciju i prijavljivanje korisnika
    /// </summary>
    public class AccountController : BaseApiController
    {
        UserManager<AppUser> userManager;
        SignInManager<AppUser> signInManager;
        private ITokenService tokenService;
        private IMapper mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Metoda koja sluzi za registraciju novih korisnika
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns>UserDto koji sadrzi podatke o korisniku i JWT tokenu</returns>

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
            var user = mapper.Map<AppUser>(registerDto);



            user.UserName = registerDto.Username.ToLower();


            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            List<int> likes = new List<int>();
            foreach (Like like in user.Likes)
            {
                likes.Add(like.DestinationId);
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = await tokenService.CreateToken(user),
                Likes = likes
            };

        }

        /// <summary>
        /// Metoda koja sluzi za prijavljivanje korisnika na sistem
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns>UserDto koji sadrzi podatke o korisniku i JWT tokenu</returns>
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await userManager.Users
                .Include(u => u.Likes)
                //.Include(p => p.Photos) #NE ZABORAVI NA OVAJ DEO SA FOTKAMA I U REPOZITORIJUMU !!!!
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user == null) return Unauthorized("Invalid username");

            if (user.Likes == null) user.Likes = new List<Like>();


            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized();


            List<int> likes = new List<int>();
            foreach (Like like in user.Likes)
            {
                likes.Add(like.DestinationId);
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = await tokenService.CreateToken(user),
                Likes = likes

            };
        }

        /// <summary>
        /// Metoda koja sluzi za proveru da li korisnik postoji u bazi
        /// </summary>
        /// <param name="username"></param>
        /// <returns>boolean vrednost koja govori da li korisnik postoji ili ne u bazi podataka</returns>
        private async Task<bool> UserExists(string username)
        {
            return await userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }


    }
}
