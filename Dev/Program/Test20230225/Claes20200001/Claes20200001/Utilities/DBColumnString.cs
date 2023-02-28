using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Utilities
{
	public class DBColumnString : DBColumn
	{
		public override string ToDBValueString(string value)
		{
			return "'" + BitConverter.ToString(Encoding.UTF8.GetBytes(value)) + "'";
		}

		public override string FromDBValueString(string value)
		{
			return Encoding.UTF8.GetString(SCommon.Hex.ToBytes(value.Replace("-", "")));
		}
	}
}
