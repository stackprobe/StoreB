using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Utilities
{
	public class DBColumnLong : DBColumn
	{
		public string ToDBValueString(long value)
		{
			return value.ToString();
		}

		public string ToDBValueString(string value)
		{
			return this.ToDBValueString(long.Parse(value));
		}

		public long ToLongFromDBValueString(string value)
		{
			return long.Parse(value);
		}

		public string ToStringFromDBValueString(string value)
		{
			return this.ToLongFromDBValueString(value).ToString();
		}
	}
}
