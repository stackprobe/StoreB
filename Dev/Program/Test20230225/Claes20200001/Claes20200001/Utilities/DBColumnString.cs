using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Utilities
{
	public class DBColumnString : DBColumn
	{
		public string ToDBValueString(long value)
		{
			return this.ToDBValueString(value.ToString());
		}

		public string ToDBValueString(string value)
		{
			return "'" + BitConverter.ToString(Encoding.UTF8.GetBytes(value)) + "'";
		}

		public long ToLongFromDBValueString(string value)
		{
			return long.Parse(this.ToStringFromDBValueString(value));
		}

		public string ToStringFromDBValueString(string value)
		{
			return Encoding.UTF8.GetString(SCommon.Hex.ToBytes(value.Replace("-", "")));
		}
	}
}
