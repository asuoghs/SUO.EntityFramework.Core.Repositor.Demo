using System;
using System.Collections.Generic;
using System.Text;
using SUO.EntityFramework.Core.Repository.EntityInterface;

namespace SUO.Model
{
    public class UserInfo : PrimaryKeyGuid, ISoftDelete
    {

        public string UserName { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedUser { get; set; }
        public bool IsDeleted { get; set; }
        public Guid UserInfoDetailedId { get; set; }
 
        public virtual UserInfoDetailed UserInfoDetailed { get; set; }
    }

    public class UserInfos : UserInfo
    {
        public int Age { get; set; }
    }

    public class UserInfoDto 
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }


    public class UserInfoDetailed : PrimaryKeyGuid
    {

        public int Age { get; set; }

        public string Email { get; set; }

    }
}
