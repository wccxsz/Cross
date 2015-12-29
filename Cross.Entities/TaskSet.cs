using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cross.Entities
{
    /// <summary>
    /// 任务制定
    /// </summary>
    public class TaskSet : Entity
    {
        /// <summary>
        /// 拍照任务计划
        /// </summary>
        public int ImageTaskCount { get; set; } = 3;

        /// <summary>
        /// 视频拍摄任务计划
        /// </summary>
        public int VideoTaskCount { get; set; } = 1;

        /// <summary>
        /// 成长故事
        /// </summary>
        public int StoryTaskCount { get; set; } = 1;

        /// <summary>
        /// 开始提醒时间
        /// </summary>
        public DateTime AlertTime { get; set; } = DateTime.Today.AddHours(9.5);

        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public DateTime LastEditTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        public virtual IdentityUser<int> CreateUser { get; set; }
    }
}
