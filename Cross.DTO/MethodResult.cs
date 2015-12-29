using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cross.DTO
{
    /// <summary>
    /// 方法返回数据
    /// </summary>
    public class MethodResult
    {
        /// <summary>
        /// 执行是否成功
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }
    }
}
