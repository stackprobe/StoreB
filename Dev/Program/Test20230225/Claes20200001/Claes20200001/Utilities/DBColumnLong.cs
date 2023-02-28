using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Charlotte.Utilities
{
	public class DBColumnLong : DBColumn
	{
		public string ToDBValueString(string value)
		{
			return long.Parse(value).ToString();
		}

		public string FromDBValueString(string value)
		{
			return long.Parse(value).ToString();
		}
	}
}
