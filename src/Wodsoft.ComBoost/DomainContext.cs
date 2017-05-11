using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Wodsoft.ComBoost
{
    /// <summary>
    /// 领域上下文
    /// </summary>
    public abstract class DomainContext : IDomainContext
    {
        /// <summary>
        /// 服务提供器(.netCore原生)
        /// </summary>

        private IServiceProvider _ServiceProvider;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="cancellationToken"></param>
        public DomainContext(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            if (cancellationToken == null)
                throw new ArgumentNullException(nameof(cancellationToken));
            _ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// 数据字典
        /// </summary>
        private dynamic _DataBag;
        public virtual dynamic DataBag
        {
            get
            {
                if (_DataBag == null)
                    _DataBag = new DomainContextDataBag();
                return _DataBag;
            }
        }
        /// <summary>
        /// 服务取消令牌。
        /// </summary>
        public CancellationToken ServiceAborted { get; private set; }
        /// <summary>
        /// 领域服务选项
        /// </summary>
        public abstract IDomainServiceOptions Options { get; }
        /// <summary>
        /// 获取指定类型的服务对象
        /// </summary>
        /// <param name="serviceType">指定类型</param>
        /// <returns></returns>
        public virtual object GetService(Type serviceType)
        {
            //调用原生获取服务方法
            return _ServiceProvider.GetService(serviceType);
        }
    }
}
