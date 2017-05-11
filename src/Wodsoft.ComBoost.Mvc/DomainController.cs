using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wodsoft.ComBoost.Mvc
{
    public class DomainController : Controller
    {
        /// <summary>
        /// 领域提供器
        /// </summary>
        protected IDomainServiceProvider DomainProvider { get; private set; }

        /// <summary>
        /// 重写OnActionExecuting，Action执行前获取领域提供器
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            DomainProvider = HttpContext.RequestServices.GetRequiredService<IDomainServiceProvider>();
        }
        /// <summary>
        /// 创建领域上下文
        /// </summary>
        /// <returns></returns>
        protected virtual MvcDomainContext CreateDomainContext()
        {
            return new MvcDomainContext(this);
        }
    }
}
