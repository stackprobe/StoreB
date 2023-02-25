using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Charlotte.Commons;
using Charlotte.Utilities;

namespace Charlotte.Tests
{
	/// <summary>
	/// TCommon.cs テスト
	/// </summary>
	public class Test0001
	{
		public void Test01()
		{
			string str = "乃 " + SCommon.ASCII + "至";
			Console.WriteLine(str);
			str = TCommon.ToAsciiFull(str);
			Console.WriteLine(str);
			str = TCommon.ToAsciiHalf(str);
			Console.WriteLine(str);
		}
	}
}
