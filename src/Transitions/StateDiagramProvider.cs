﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <9555843@qq.com>
 *
 * Copyright (C) 2017 Zongsoft Corporation <http://www.zongsoft.com>
 *
 * This file is part of Zongsoft.CoreLibrary.
 *
 * Zongsoft.CoreLibrary is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * Zongsoft.CoreLibrary is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with Zongsoft.CoreLibrary; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */

using System;
using System.Collections.Generic;

namespace Zongsoft.Transitions
{
	public class StateDiagramProvider : IStateDiagramProvider
	{
		#region 单例字段
		public static readonly StateDiagramProvider Default = new StateDiagramProvider();
		#endregion

		#region 成员字段
		private Zongsoft.Services.IServiceProvider _serviceProvider;
		#endregion

		#region 构造函数
		public StateDiagramProvider()
		{
		}

		public StateDiagramProvider(Zongsoft.Services.IServiceProvider serviceProvider)
		{
			if(serviceProvider == null)
				throw new ArgumentNullException(nameof(serviceProvider));

			_serviceProvider = serviceProvider;
		}
		#endregion

		#region 公共属性
		public Zongsoft.Services.IServiceProvider ServiceProvider
		{
			get
			{
				return _serviceProvider;
			}
			set
			{
				_serviceProvider = value;
			}
		}
		#endregion

		#region 公共方法
		public StateDiagramBase<T> GetDiagram<T>() where T : struct
		{
			var serviceProvider = _serviceProvider ?? Zongsoft.Services.ServiceProviderFactory.Instance.Default;

			if(serviceProvider == null)
				return null;

			return serviceProvider.Resolve<StateDiagramBase<T>>();
		}
		#endregion
	}
}
