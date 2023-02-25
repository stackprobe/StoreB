using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Utilities
{
	/// <summary>
	/// 便利機能
	/// </summary>
	public static class TCommon
	{
		/// <summary>
		/// リスト内の範囲(開始位置と終了位置)を取得する。
		/// 戻り値を range とすると
		/// for (int index = range[0] + 1; index &lt; range[1]; index++) { T element = list[index]; ... }
		/// と廻すことで範囲内の要素を走査できる。
		/// 比較メソッド：
		/// -- 少なくとも以下のとおりの比較結果となること。
		/// ---- 範囲の左側の要素 &lt; 範囲内の要素
		/// ---- 範囲の左側の要素 &lt; 範囲の右側の要素
		/// ---- 範囲内の要素 == 範囲内の要素
		/// ---- 範囲内の要素 &lt; 範囲の右側の要素
		/// 範囲：
		/// -- new int[] { l, r }
		/// ---- l == 範囲の開始位置の一つ前の位置_リストの最初の要素が範囲内である場合 -1 となる。
		/// ---- r == 範囲の終了位置の一つ後の位置_リストの最後の要素が範囲内である場合 list.Count となる。
		/// </summary>
		/// <typeparam name="T">要素の型</typeparam>
		/// <param name="list">検索対象のリスト</param>
		/// <param name="targetValue">範囲内の値</param>
		/// <param name="comp">比較メソッド</param>
		/// <returns>範囲</returns>
		public static int[] GetRange<T>(IList<T> list, T targetValue, Comparison<T> comp)
		{
			return GetRange(list, element => comp(element, targetValue));
		}

		/// <summary>
		/// リスト内の範囲(開始位置と終了位置)を取得する。
		/// 戻り値を range とすると
		/// for (int index = range[0] + 1; index &lt; range[1]; index++) { T element = list[index]; ... }
		/// と廻すことで範囲内の要素を走査できる。
		/// 判定メソッド：
		/// -- 範囲の左側の要素であれば負の値を返す。
		/// -- 範囲の右側の要素であれば正の値を返す。
		/// -- 範囲内の要素であれば 0 を返す。
		/// 範囲：
		/// -- new int[] { l, r }
		/// ---- l == 範囲の開始位置の一つ前の位置_リストの最初の要素が範囲内である場合 -1 となる。
		/// ---- r == 範囲の終了位置の一つ後の位置_リストの最後の要素が範囲内である場合 list.Count となる。
		/// </summary>
		/// <typeparam name="T">要素の型</typeparam>
		/// <param name="list">検索対象のリスト</param>
		/// <param name="comp">判定メソッド</param>
		/// <returns>範囲</returns>
		public static int[] GetRange<T>(IList<T> list, Func<T, int> comp)
		{
			int l = -1;
			int r = list.Count;

			while (l + 1 < r)
			{
				int m = (l + r) / 2;
				int ret = comp(list[m]);

				if (ret < 0)
				{
					l = m;
				}
				else if (0 < ret)
				{
					r = m;
				}
				else
				{
					l = GetLeft(list, l, m, element => comp(element) < 0);
					r = GetLeft(list, m, r, element => comp(element) == 0) + 1;
					break;
				}
			}
			return new int[] { l, r };
		}

		private static int GetLeft<T>(IList<T> list, int l, int r, Predicate<T> isLeft)
		{
			while (l + 1 < r)
			{
				int m = (l + r) / 2;
				bool ret = isLeft(list[m]);

				if (ret)
				{
					l = m;
				}
				else
				{
					r = m;
				}
			}
			return l;
		}
	}
}
