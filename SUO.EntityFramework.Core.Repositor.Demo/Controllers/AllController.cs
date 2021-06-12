using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SUO.EntityFramework.Core.Repositor.Demo.Context;

using SUO.EntityFramework.Core.Repository;
using SUO.Model;
using SUO.Swagger.Attribute;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SUO.EntityFramework.Core.Repositor.Demo.Controllers
{
    /// <summary>
    /// 查询所有
    /// </summary>
    [ApiController]
    [ApiGroup("ALL")]
    [Route("[controller]")]
    public class AllController : Controller
    {
        private readonly IBaseRepository<UserInfo, Guid, MyContext> _userRepository;
        public AllController(IBaseRepository<UserInfo, Guid, MyContext> _userRepository)
        {
            this._userRepository = _userRepository;
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [Route("All")]
        [HttpGet]
        public ActionResult All()
        {
           
            return Json(_userRepository.All());
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [Route("AllAsync")]
        [HttpGet]
        public async Task<ActionResult> AllAsync()
        {

            return Json(await _userRepository.AllAsync());
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [Route("AllAsNoTracking")]
        [HttpGet]
        public ActionResult AllAsNoTracking()
        {

            return Json(_userRepository.AllAsNoTracking());
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [Route("AllAsyncNoTracking")]
        [HttpGet]
        public async Task<ActionResult> AllAsyncNoTracking()
        {

            return Json(await _userRepository.AllAsyncNoTracking());
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [Route("AllIncluding")]
        [HttpGet]
        public ActionResult AllIncluding()
        {

            return Json(_userRepository.AllIncluding(a=>a.UserInfoDetailed));
        }

    }
}
