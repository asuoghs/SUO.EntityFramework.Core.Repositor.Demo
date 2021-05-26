using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SUO.EntityFramework.Core.Repository.EntityInterface;

namespace SUO.EntityFramework.Core.Repositor.Demo.Model
{
    public class UserInfo : PrimaryKeyGuid,ISoftDelete
    {
        public string UserName { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedUser { get; set; }
        public bool IsDeleted { get; set; }


        public virtual UserInfoDetailed UserInfoDetailed { get; set; }
    }


    public class UserInfoDetailed: PrimaryKeyGuid
    {

        public int Age { get; set; }

        public string Email { get; set; }

    }
}
