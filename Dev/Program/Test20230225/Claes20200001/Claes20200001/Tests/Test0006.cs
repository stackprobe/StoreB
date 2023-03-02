using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0006
	{
		public void Test01()
		{
			for (int n = 1; n <= 101; n++)
			{
				Test01_a(n);
			}
		}

		private void Test01_a(int n)
		{
			int win = 0;
			int winCnt = 0;
			int lose = 0;
			int losePos = 0;

			for (int testCnt = 0; testCnt < 30000; testCnt++)
			{
				int c = 0;
				int p = 0;

				while (c < n)
				{
					c++;
					p += SCommon.CRandom.GetSign();

					if (p < 0)
					{
						break;
					}
				}
				if (p < 0)
				{
					win++;
					winCnt += c;
				}
				else
				{
					lose++;
					losePos += p;
				}
			}
			Console.WriteLine(n + " ==> " + (win * 1.0 / (win + lose)).ToString("F9")
				+ " , " + (winCnt * 1.0 / win).ToString("F9")
				+ " , " + (losePos * 1.0 / lose).ToString("F9")
				);
		}

		public void Test02()
		{
			//
		}
	}
}
