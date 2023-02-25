using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte
{
	public static class Common
	{
		public static string HalfToFull(string str)
		{
			return Common.ReplaceChars(str, " " + SCommon.DECIMAL, "　" + SCommon.MBC_DECIMAL); // 必要に応じて増やすこと。
		}

		private static string ReplaceChars(string str, string fromChrs, string toChrs)
		{
			int chrCount = fromChrs.Length;

			if (chrCount != toChrs.Length)
				throw null; // Bad params

			return new string(str.Select(chr =>
			{
				for (int index = 0; index < chrCount; index++)
					if (chr == fromChrs[index])
						return toChrs[index];

				return chr;
			})
			.ToArray());
		}
	}
}
