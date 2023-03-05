﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Charlotte.Commons;
using Charlotte.Tests;

namespace Charlotte
{
	class Program
	{
		static void Main(string[] args)
		{
			ProcMain.CUIMain(new Program().Main2);
		}

		private void Main2(ArgsReader ar)
		{
			if (ProcMain.DEBUG)
			{
				Main3();
			}
			else
			{
				Main4();
			}
			SCommon.OpenOutputDirIfCreated();
		}

		private void Main3()
		{
			Main4();
			SCommon.Pause();
		}

		private void Main4()
		{
			try
			{
				Main5();
			}
			catch (Exception ex)
			{
				ProcMain.WriteLog(ex);
			}
		}

		private void Main5()
		{
			// -- choose one --

			//new Test0001().Test01(); // Make Csv
			//new Test0001().Test02(); // Csv Tokyo
			//new Test0001().Test03(); // Csv MOD 13
			//new Test0001().Test04(); // Make DB
			//new Test0001().Test05(); // DB Tokyo
			//new Test0001().Test06(); // DB MOD 13
			//new Test0002().Test01();
			//new Test0002().Test02();
			//new Test0003().Test01();
			//new Test0004().Test01();
			//new Test0005().Test01();
			//new Test0006().Test01();
			//new Test0006().Test02();
			//new Test0007().Test01();
			new Test0007().Test02();

			// --
		}
	}
}
