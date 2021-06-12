using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization.Internal;
using SUO.EntityFramework.Core.Repositor.Demo.Context;

using SUO.EntityFramework.Core.Repository;
using SUO.Model;
using SUO.Swagger.Attribute;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SUO.EntityFramework.Core.Repositor.Demo.Controllers
{
    /// <summary>
    /// 所有的删除方法
    /// </summary>
    [ApiController]
    [ApiGroup("REMOVE")]
    [Route("[controller]")]
    public class RemoveController : Controller
    {
        private readonly IBaseRepository<UserInfo, Guid, MyContext> _userRepository;
        public RemoveController(IBaseRepository<UserInfo, Guid, MyContext> _userRepository)
        {
            this._userRepository = _userRepository;
        }

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <returns></returns>
        [Route("Remove")]
        [HttpPost]
        public ActionResult Remove(Guid id)
        {
            int u = _userRepository.Remove(a => a.Id == id);
            this._userRepository.Commit();
            return Json(u);
        }
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <returns></returns>
        [Route("RemoveAsync")]
        [HttpPost]
        public async Task<ActionResult> RemoveAsync(Guid id)
        {
            int u =await _userRepository.RemoveAsync(a => a.Id == id);
           await this._userRepository.CommitAsync();
            return Json(u);
        }
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <returns></returns>
        [Route("RemoveEntity")]
        [HttpPost]
        public ActionResult RemoveEntity(Guid id)
        {
            var userinfo=_userRepository.Single(id);
            userinfo = _userRepository.Remove(userinfo);
            this._userRepository.Commit();
            return Json(userinfo);
        }
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <returns></returns>
        [Route("RemoveEntityAsync")]
        [HttpPost]
        public async Task<ActionResult> RemoveEntityAsync(Guid id)
        {
            var userinfo = _userRepository.SingleAsNoTracking(id);
            userinfo = await _userRepository.RemoveAsync(userinfo);
            await this._userRepository.CommitAsync();
            return Json(userinfo);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns></returns>
        [Route("RemoveIds")]
        [HttpPost]
        public ActionResult RemoveIds(Guid[] ids)
        {
           int userinfo = _userRepository.Remove(ids);
            this._userRepository.Commit();
            return Json(userinfo);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns></returns>
        [Route("RemoveIdsAsync")]
        [HttpPost]
        public async Task<ActionResult> RemoveIdsAsync(Guid[] ids)
        {
            int userinfo =await _userRepository.RemoveAsync(ids);
            this._userRepository.Commit();
            return Json(userinfo);
        }

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <returns></returns>
        [Route("RemoveId")]
        [HttpPost]
        public ActionResult RemoveId(Guid id)
        {
            var u = _userRepository.Remove(id);
            this._userRepository.Commit();
            return Json(u);
        }
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <returns></returns>
        [Route("RemoveIdAsync")]
        [HttpPost]
        public async Task<ActionResult> RemoveIdAsync(Guid id)
        {
            var u = await _userRepository.RemoveAsync(id);
            await this._userRepository.CommitAsync();
            return Json(u);
        }
    }
}
