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
    /// 所有的添加方法
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AddController : Controller
    {
        private readonly IBaseRepository<UserInfo, Guid,MyContext> _userRepository;

        private readonly IBaseRepository<UserInfo, Guid, My01Context> _user01Repository;


        public AddController(IBaseRepository<UserInfo, Guid, MyContext> _userRepository, IBaseRepository<UserInfo, Guid, My01Context> _user01Repository)
        {
            this._userRepository = _userRepository;
            this._user01Repository = _user01Repository;
        }
        /// <summary>
        /// 单个添加
        /// </summary>
        /// <returns></returns>
        [Route("add")]
        [ApiGroup("ADD")]
        [HttpGet]
        public ActionResult Add()
        {
            Guid id = new Guid();
            UserInfo u = _userRepository.Add(new UserInfo()
                { Id = id, UserName = "张三", UserInfoDetailed = new UserInfoDetailed() { Id = id, Age = 11 } });
            _userRepository.Commit();
            return Json(u);
        }
        /// <summary>
        /// 单个添加Add01
        /// </summary>
        /// <returns></returns>
        [Route("Add01")]
        [ApiGroup("ADD")]
        [HttpGet]
        public ActionResult Add01()
        {
            Guid id = new Guid();
            UserInfo u = _user01Repository.Add(new UserInfo()
                { Id = id, UserName = "张三", UserInfoDetailed = new UserInfoDetailed() { Id = id, Age = 11 } });
            _user01Repository.Commit();
            return Json(u);
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <returns></returns>
        [Route("AddRange")]
        [ApiGroup("ADD")]
        [HttpGet]
        public ActionResult AddRange()
        {
           
            List<UserInfo> list = new List<UserInfo>();
            for (int i = 0; i <=3; i++)
            {
                Guid id = new Guid();
                list.Add(new UserInfo()
                {
                    Id =id,
                    UserName = "张三",
                    UserInfoDetailed = new UserInfoDetailed()
                    {
                        Age = 11,
                        Id =id

                    }
                });
            }

            _userRepository.AddRange(list);
            _userRepository.Commit();
            return Json("ok");
        }

        /// <summary>
        /// 单个添加async
        /// </summary>
        /// <returns></returns>
        [Route("AddAsync")]
        [ApiGroup("ADD")]
        [HttpGet]
        public async Task<ActionResult> AddAsync()
        {
            Guid id = new Guid();
            UserInfo u =await _userRepository.AddAsync(new UserInfo()
                { Id = id, UserName = "张三", UserInfoDetailed = new UserInfoDetailed() { Id = id, Age = 11 } });
            _userRepository.Commit();
            return Json(u);
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <returns></returns>
        [Route("AddRangeAsync")]
        [ApiGroup("ADD")]
        [HttpGet]
        public async Task<ActionResult> AddRangeAsync()
        {
            List<UserInfo> list = new List<UserInfo>();
            for (int i = 0; i <= 3; i++)
            {
                Guid id = new Guid();
                list.Add(new UserInfo()
                {
                    Id = id,
                    UserName = "张三",
                    UserInfoDetailed = new UserInfoDetailed()
                    {
                        Age = 11,
                        Id = id

                    }
                });
            }

            await _userRepository.AddRangeAsync(list);
            _userRepository.Commit();
            return Json("ok");
        }
    }
}
