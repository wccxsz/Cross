using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Cross.Entities
{
    /// <summary>
    /// 我的计划
    /// </summary>
    public class Task : Entity
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 完成时间
        /// </summary>
        public virtual DateTime FinishedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        public virtual IdentityUser<int> CreateUser { get; set; }
    }
}
