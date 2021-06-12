using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SUO.EntityFramework.Core.Repository;
using SUO.Swagger.Attribute;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SUO.EntityFramework.Core.Repositor.Demo.Context;
using SUO.Model;


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
        private readonly IBaseRepository<UserInfo, Guid, MyContext> _userRepository;
        public FormSqlController(IBaseRepository<UserInfo, Guid, MyContext> _userRepository)
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
            FormattableString message = $"  select [UserInfo].*,UserInfoDetailed.Age,UserInfoDetailed.Email from [UserInfo] inner join [UserInfoDetailed] on userinfo.[UserInfoDetailedId]=[UserInfoDetailed].id ";
          var s=  _userRepository.Page(a=>true, "DeletedDate asc", 1, 3).ToList();
            return Json(_userRepository.FromSqlQueryable(message).ProjectTo<UserInfos>(new MapperConfiguration(cfg => cfg.CreateMap<UserInfos, UserInfo>())).Select(a=>new UserInfos()
            {
                Age = a.UserInfoDetailed.Age
            }));
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
