﻿/*
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2003-2014 Zongsoft Corporation <http://www.zongsoft.com>
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

namespace Zongsoft.Security.Membership
{
	public struct PermissionFilter
	{
		#region 成员变量
		private string _schemaId;
		private string _actionId;
		private string _filter;
		#endregion

		#region 构造函数
		public PermissionFilter(string schemaId, string actionId, string filter)
		{
			if(string.IsNullOrEmpty(schemaId))
				throw new ArgumentNullException(nameof(schemaId));
			if(string.IsNullOrEmpty(actionId))
				throw new ArgumentNullException(nameof(actionId));
			if(string.IsNullOrEmpty(filter))
				throw new ArgumentNullException(nameof(filter));

			_schemaId = schemaId.Trim();
			_actionId = actionId.Trim();
			_filter = filter.Trim();
		}
		#endregion

		#region 公共属性
		public string SchemaId
		{
			get
			{
				return _schemaId;
			}
			set
			{
				if(string.IsNullOrEmpty(value))
					throw new ArgumentNullException();

				_schemaId = value.Trim();
			}
		}

		public string ActionId
		{
			get
			{
				return _actionId;
			}
			set
			{
				if(string.IsNullOrEmpty(value))
					throw new ArgumentNullException();

				_actionId = value.Trim();
			}
		}

		public string Filter
		{
			get
			{
				return _filter;
			}
			set
			{
				if(string.IsNullOrEmpty(value))
					throw new ArgumentNullException();

				_filter = value.Trim();
			}
		}
		#endregion

		#region 重写方法
		public override bool Equals(object obj)
		{
			if(obj == null || obj.GetType() != this.GetType())
				return false;

			var other = (PermissionFilter)obj;

			return string.Equals(_schemaId, other._schemaId, StringComparison.OrdinalIgnoreCase) &&
			       string.Equals(_actionId, other._actionId, StringComparison.OrdinalIgnoreCase) &&
			       string.Equals(_filter, other._filter, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode()
		{
			return (_schemaId + ":" + _actionId + ":" + _filter).ToLowerInvariant().GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0}:{1}\r\n{2}", _schemaId, _actionId, _filter);
		}
		#endregion
	}
}
