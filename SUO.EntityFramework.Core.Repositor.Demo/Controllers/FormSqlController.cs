using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SUO.EntityFramework.Core.Repository;
using SUO.Model;
using SUO.Swagger.Attribute;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SUO.EntityFramework.Core.Repositor.Demo.Controllers
{
    /// <summary>
    /// 执行特殊sql语句
    /// </summary>
    [ApiController]
    [ApiGroup("Sql")]
    [Route("[controller]")]
    public class FormSqlController : Controller
    {
        private readonly IBaseRepository<UserInfo, Guid> _userRepository;
        public FormSqlController(IBaseRepository<UserInfo, Guid> _userRepository)
        {
            this._userRepository = _userRepository;
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [Route("FromSqlList")]
        [HttpGet]
        public ActionResult FromSqlList()
        {
            string name = "111";
            FormattableString message = $"  select [UserInfo].*,UserInfoDetailed.Age,UserInfoDetailed.Email from [UserInfo] inner join [UserInfoDetailed] on userinfo.[UserInfoDetailedId]=[UserInfoDetailed].id {name} ";
            var s= message.ToString();
            return Json(_userRepository.FromSqlList(message));
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [Route("FromSqlListAsync")]
        [HttpGet]
        public async Task<ActionResult> FromSqlListAsync()
        {
            FormattableString message = $"select * from [UserInfo] ";
            return Json(await _userRepository.FromSqlListAsync(message));
        }

         
    }
}
