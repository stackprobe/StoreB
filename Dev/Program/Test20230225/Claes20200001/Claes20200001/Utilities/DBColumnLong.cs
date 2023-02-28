using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Utilities
{
	public class DBColumnLong : DBColumn
	{
		public override string ToDBValueString(string value)
		{
			return long.Parse(value).ToString();
		}

		public override string FromDBValueString(string value)
		{
			return long.Parse(value).ToString();
		}
	}
}
