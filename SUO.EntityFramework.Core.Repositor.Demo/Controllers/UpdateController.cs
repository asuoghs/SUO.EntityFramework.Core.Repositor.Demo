using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization.Internal;
using SUO.EntityFramework.Core.Repository;
using SUO.Model;
using SUO.Swagger.Attribute;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SUO.EntityFramework.Core.Repositor.Demo.Controllers
{
    /// <summary>
    /// 所有的更新方法
    /// </summary>
    [ApiController]
    [ApiGroup("UPDATE")]
    [Route("[controller]")]
    public class UpdateController : Controller
    {
        private readonly IBaseRepository<UserInfo, Guid> _userRepository;
        public UpdateController(IBaseRepository<UserInfo, Guid> _userRepository)
        {
            this._userRepository = _userRepository;
        }

        /// <summary>
        /// 单个更新
        /// </summary>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        public ActionResult Update(Guid id,string name)
        {
            UserInfo u = _userRepository.Update(id, a => { a.UserName = name; });
            this._userRepository.Commit();
            return Json(u);
        }
        /// <summary>
        /// 单个更新
        /// </summary>
        /// <returns></returns>
        [Route("UpdateAsync")]
        [HttpPost]
        public async Task<ActionResult> UpdateAsync(Guid id, string name)
        {
            UserInfo u =  await _userRepository.UpdateAsync(id, (x) =>
             {
                 x.UserName = name;
             });
            await this._userRepository.CommitAsync();
            return Json(u);
        }

        /// <summary>
        /// 单个更新
        /// </summary>
        /// <returns></returns>
        [Route("UpdateS")]
        [HttpPost]
        public ActionResult UpdateS(Guid id, string name)
        {
            UserInfo u = _userRepository.Single(a=>a.Id==id);
            u.UserName = name;

            //UserInfo u = _userRepository.SingleAsNoTracking(a => a.Id == id);
            //u = new UserInfo()
            //{
            //    UserName = name,
            //    DeletedDate = DateTime.Now,
            //    DeletedUser = "22",
            //    Id = id,
            //    IsDeleted = true,
            //    UserInfoDetailedId = new Guid("78480EAC-D261-49E4-C47E-08D921DEEB46")
            //};
            //u.UserName = name;
            //_userRepository.Update(u);
            this._userRepository.Commit();
            return Json(u);
        }
        /// <summary>
        /// 单个更新
        /// </summary>
        /// <returns></returns>
        [Route("UpdateSAsync")]
        [HttpPost]
        public async Task<ActionResult> UpdateSAsync(Guid id, string name)
        {
            UserInfo u = await _userRepository.SingleAsync(id);
          await  _userRepository.UpdateAsync(u);
            u.UserName = name;
         
            await this._userRepository.CommitAsync();
            return Json(u);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <returns></returns>
        [Route("UpdateRange")]
        [HttpPost]
        public ActionResult UpdateRange()
        {
            int u = _userRepository.UpdateRange(a => a.UserName.Contains("张三"), b => new UserInfo(){DeletedUser = "aaabd"});
            return Json(u);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <returns></returns>
        [Route("UpdateRangeAsync")]
        [HttpPost]
        public async Task<ActionResult> UpdateRangeAsync()
        {
            int u =await _userRepository.UpdateRangeAsync(a => a.UserName.Contains("张三"), b => new UserInfo() { DeletedDate = DateTime.Now});
            return Json(u);
        }
    }
}
