using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using NexusCanadaTech.Web.API.Core.Contracts.Services;
using NexusCanadaTech.Web.API.Core.DbModels;
using NexusCanadaTech.Web.API.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NexusCanadaTech.Web.API.Controllers
{

    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        #region Private DataMember

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// GET api/User   
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = this._userService.GetAll();
            return users;
        }

        /// <summary>
        /// GET api/GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var user = this._userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        /// <summary>
        /// GET api/GetByName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}", Name = "GetByName")]
        //[Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            var user = this._userService.GetByName(name);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        /// <summary>
        /// POST api/User
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(UserDTO userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }
            var user = new User();
            if (userModel.ImageFile != null && userModel.ImageFile.Length != 0)
            {
                byte[] filebytes = null;
                using (var stream = userModel.ImageFile.OpenReadStream())
                {
                    using (var binaryReader = new BinaryReader(stream))
                    {
                        filebytes = binaryReader.ReadBytes((int)userModel.ImageFile.Length);
                    }
                }
                user.Picture = filebytes;
            }
            user.IsAuthenticated = false;
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Email = userModel.Email;
            user.Interests = userModel.Interests;
            user.OauthInfo = userModel.OauthInfo;
            user.DateCreated = DateTime.UtcNow;
            user.IsDeleted = false;
            user.IsAuthenticated = false;


            try
            {
                _userService.Insert(user);
                _userService.Save();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetById", new { id = user.Id }, user);
        }

        /// <summary>
        /// PUT api/User/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            var dbUser = this._userService.GetById(id);
            if (dbUser == null)
            {
                return NotFound();
            }
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            dbUser.Interests = user.Interests;
            dbUser.OauthInfo = user.OauthInfo;
            dbUser.DateModified = DateTime.UtcNow;
            dbUser.Picture = user.Picture;
            dbUser.IsDeleted = false;
            dbUser.Email = user.Email;
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Interests = user.Interests;
            user.IsAuthenticated = false;
            this._userService.Update(dbUser);
            this._userService.Save();
            return new NoContentResult();
        }

        /// <summary>
        /// DELETE api/User/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = this._userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            this._userService.Delete(user.Id);
            this._userService.Save();
            return new NoContentResult();
        }

        #endregion
    }
}
