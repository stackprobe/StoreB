using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0006
	{
		private class RecordInfo
		{
			public int Group;
			public int Value;
		}

		private class SummaryInfo
		{
			public int Group;
			public int Total;
			public int Low;
			public int Hi;
			public int Avg;

			public static int Comp(SummaryInfo a, SummaryInfo b)
			{
				int ret = a.Group - b.Group;
				if (ret != 0)
					return ret;

				ret = a.Avg - b.Avg;
				if (ret != 0)
					return ret;

				ret = a.Low - b.Low;
				if (ret != 0)
					return ret;

				ret = a.Hi - b.Hi;
				if (ret != 0)
					return ret;

				ret = a.Total - b.Total;
				return ret;
			}
		}

		public void Test01()
		{
			Test01_a(1, 1, 1); // 長さゼロ

			foreach (int a in new int[] { 10, 30, 100, 300 })
			{
				foreach (int b in new int[] { 10, 30, 100, 300 })
				{
					foreach (int c in new int[] { 10, 30, 100, 300 })
					{
						Console.WriteLine(string.Join(", ", a, b, c));

						for (int testCnt = 0; testCnt < 1000; testCnt++)
						{
							Test01_a(a, b, c);
						}
						Console.WriteLine("OK");
					}
				}
			}
			Console.WriteLine("OK!");
		}

		private void Test01_a(int countScale, int groupScale, int valueScale)
		{
			int count = SCommon.CRandom.GetInt(countScale);
			int groupMin = 1;
			int groupMax = SCommon.CRandom.GetInt(groupScale) + 1;
			int valueMin = 1;
			int valueMax = SCommon.CRandom.GetInt(valueScale) + 1;

			List<RecordInfo> records = new List<RecordInfo>();

			while (records.Count < count)
			{
				records.Add(new RecordInfo()
				{
					Group = SCommon.CRandom.GetRange(groupMin, groupMax),
					Value = SCommon.CRandom.GetRange(valueMin, valueMax),
				});
			}
			records.Sort((a, b) => a.Group - b.Group);

			SummaryInfo[] summaries1 = Test01_b(records);
			SummaryInfo[] summaries2 = Test01_c(records);
			SummaryInfo[] summaries3 = Test01_d(records);
			SummaryInfo[] summaries4 = Test01_e(records);
			SummaryInfo[] summaries5 = Test01_f(records);

			if (SCommon.Comp(summaries1, summaries2, (a, b) => SummaryInfo.Comp(a, b)) != 0)
				throw null; // ng !!!

			if (SCommon.Comp(summaries1, summaries3, (a, b) => SummaryInfo.Comp(a, b)) != 0)
				throw null; // ng !!!

			if (SCommon.Comp(summaries1, summaries4, (a, b) => SummaryInfo.Comp(a, b)) != 0)
				throw null; // ng !!!

			if (SCommon.Comp(summaries1, summaries5, (a, b) => SummaryInfo.Comp(a, b)) != 0)
				throw null; // ng !!!
		}

		private SummaryInfo[] Test01_b(IList<RecordInfo> records)
		{
			List<SummaryInfo> dest = new List<SummaryInfo>();

			for (int start = 0; start < records.Count; )
			{
				int end = SCommon.IndexOf(records, v => records[start].Group != v.Group, start + 1);

				if (end == -1)
					end = records.Count;

				int count = end - start;

				SummaryInfo summary = new SummaryInfo()
				{
					Group = records[start].Group,
					Total = 0,
					Low = int.MaxValue,
					Hi = int.MinValue,
					//Avg = -1,
				};

				for (int index = start; index < end; index++)
				{
					summary.Total += records[index].Value;
					summary.Low = Math.Min(summary.Low, records[index].Value);
					summary.Hi = Math.Max(summary.Hi, records[index].Value);
				}
				summary.Avg = summary.Total / count;

				dest.Add(summary);

				start = end;
			}
			return dest.ToArray();
		}

		private SummaryInfo[] Test01_c(IEnumerable<RecordInfo> records)
		{
			List<SummaryInfo> dest = new List<SummaryInfo>();
			SummaryInfo summary = null;
			int count = 0;

			foreach (RecordInfo record in records.Concat(new RecordInfo[] { null }))
			{
				if (summary != null && (record == null || record.Group != summary.Group))
				{
					summary.Avg = summary.Total / count;

					dest.Add(summary);

					summary = null;
				}
				if (summary == null)
				{
					if (record == null)
						break;

					summary = new SummaryInfo()
					{
						Group = record.Group,
						Total = 0,
						Low = int.MaxValue,
						Hi = int.MinValue,
						//Avg = -1,
					};

					count = 0;
				}
				summary.Total += record.Value;
				summary.Low = Math.Min(summary.Low, record.Value);
				summary.Hi = Math.Max(summary.Hi, record.Value);

				count++;
			}
			return dest.ToArray();
		}

		private SummaryInfo[] Test01_d(IEnumerable<RecordInfo> records)
		{
			IEnumerator<RecordInfo> reader = records.GetEnumerator();
			List<SummaryInfo> dest = new List<SummaryInfo>();
			SummaryInfo summary = null;
			int count = 0;

			for (; ; )
			{
				bool hasCurr = reader.MoveNext();

				// グループ終了時の処理
				if (summary != null && (!hasCurr || reader.Current.Group != summary.Group))
				{
					summary.Avg = summary.Total / count;

					dest.Add(summary);

					summary = null;
				}

				// グループ開始時の処理
				if (summary == null)
				{
					if (!hasCurr)
						break;

					summary = new SummaryInfo()
					{
						Group = reader.Current.Group,
						Total = 0,
						Low = int.MaxValue,
						Hi = int.MinValue,
						//Avg = -1,
					};

					count = 0;
				}

				summary.Total += reader.Current.Value;
				summary.Low = Math.Min(summary.Low, reader.Current.Value);
				summary.Hi = Math.Max(summary.Hi, reader.Current.Value);

				count++;
			}

			reader.Dispose();

			return dest.ToArray();
		}

		private SummaryInfo[] Test01_e(IList<RecordInfo> records)
		{
			List<SummaryInfo> dest = new List<SummaryInfo>();
			SummaryInfo summary = null;
			int count = 0;

			Action<RecordInfo> startGroup = record =>
			{
				summary = new SummaryInfo()
				{
					Group = record.Group,
					Total = 0,
					Low = int.MaxValue,
					Hi = int.MinValue,
					//Avg = -1,
				};

				count = 0;
			};

			Action endGroup = () =>
			{
				summary.Avg = summary.Total / count;

				dest.Add(summary);
			};

			if (1 <= records.Count)
			{
				startGroup(records[0]);

				foreach (RecordInfo record in records)
				{
					if (summary.Group != record.Group)
					{
						endGroup();
						startGroup(record);
					}

					summary.Total += record.Value;
					summary.Low = Math.Min(summary.Low, record.Value);
					summary.Hi = Math.Max(summary.Hi, record.Value);

					count++;
				}
				endGroup();
			}

			return dest.ToArray();
		}

		private SummaryInfo[] Test01_f(IList<RecordInfo> records)
		{
			List<SummaryInfo> dest = new List<SummaryInfo>();
			SummaryInfo summary = null;
			int count = 0;

			Action<RecordInfo> firstGroupRecord = record =>
			{
				summary = new SummaryInfo()
				{
					Group = record.Group,
					Total = record.Value,
					Low = record.Value,
					Hi = record.Value,
					//Avg = -1,
				};

				count = 1;
			};

			Action<RecordInfo> trailGroupRecord = record =>
			{
				summary.Total += record.Value;
				summary.Low = Math.Min(summary.Low, record.Value);
				summary.Hi = Math.Max(summary.Hi, record.Value);

				count++;
			};

			Action endGroup = () =>
			{
				summary.Avg = summary.Total / count;

				dest.Add(summary);
			};

			if (1 <= records.Count)
			{
				firstGroupRecord(records[0]);

				foreach (RecordInfo record in records.Skip(1))
				{
					if (summary.Group != record.Group) // ? group changed
					{
						endGroup();
						firstGroupRecord(record);
					}
					else
					{
						trailGroupRecord(record);
					}
				}
				endGroup();
			}

			return dest.ToArray();
		}
	}
}
