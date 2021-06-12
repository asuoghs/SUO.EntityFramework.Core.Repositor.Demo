using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace netcorewebapi.Controllers
{
    /// <summary>
    /// TestController
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private IOperationTransient _id;
        private IOperationScoped _idScope;
        private ABC abc;

        public TestController(IOperationTransient id, IOperationScoped _idScope,ABC abc)
        {
            _id = id;
            this._idScope = _idScope;
            this.abc = abc;
        }

        /// <summary>
        ///  GET api/values/6
        /// </summary>
        /// <param name="id">abc</param>
        /// <returns>1</returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            int s = _id.GetHashCode();
            IOperationTransient s1 = (HttpContext.RequestServices.GetService(typeof(IOperationTransient))) as IOperationTransient;
            int s2=s1.GetHashCode();
            return _id.OperationId.ToString();
        }
        [HttpGet]
        public ActionResult<string> Get2()
        {
            int s = _idScope.GetHashCode();
            IOperationScoped s1 = (HttpContext.RequestServices.GetService(typeof(IOperationScoped))) as IOperationScoped;
            int s2 = s1.GetHashCode();
            return _id.OperationId.ToString();
        }
    }

    public interface IOperation
    {
        Guid OperationId { get; }
    }
    public interface IOperationSingleton : IOperation { }
    public interface IOperationTransient : IOperation { }
    public interface IOperationScoped : IOperation { }

    public class OperationTest :
        IOperationSingleton,
        IOperationTransient,
        IOperationScoped
    {
        private Guid _guid;

        public OperationTest()
        {
            _guid = Guid.NewGuid();
        }

        public OperationTest(Guid guid)
        {
            _guid = guid;
        }

        public Guid OperationId => _guid;
    }

    public class ABC
    {
        public ABC()
        {

        }
    }

}
