package tests.charlotte.commons;

import java.util.ArrayList;
import java.util.List;

import charlotte.commons.SCommon;

public class Test0002 {
	public static void main(String[] args) {
		try {
			new Test0002().test01();
		}
		catch (Throwable e) {
			e.printStackTrace();
		}
	}

	private void test01() {
		createDb();

		// TODO
		// TODO
		// TODO

		System.out.println("*1");
	}

	private class ContInf {
		public int memNo;
		public int level;
		public int relYm;
	}

	private class LessStdyRcd {
		public int memNo;
		public int level;
		public int stdyNum;
		public int lessNum;
		public int cortNum;
		public int quesNum;
	}

	private List<ContInf> contInfs;
	private List<List<LessStdyRcd>> lessStdyRcdsList;

	private void createDb() {
		contInfs = new ArrayList<ContInf>();
		lessStdyRcdsList = new ArrayList<List<LessStdyRcd>>();

		for (int t = 0; t < 10; t++) {
			lessStdyRcdsList.add(new ArrayList<LessStdyRcd>());

			for (int u = 0; u < 10; u++) {
				int memNo = t * 10 + u;

				for (int level = 0; level < 100; level++) {
					if (SCommon.cryptRandom.getInt(30) == 0) {
						ContInf contInf = new ContInf();
						contInf.memNo = memNo;
						contInf.level = level;
						contInf.relYm =
								SCommon.cryptRandom.getRange(1900, 2100) * 100 +
								SCommon.cryptRandom.getRange(1, 12);
						contInfs.add(contInf);

						int lessNum = SCommon.cryptRandom.getRange(1, 99);
						int quesNum = SCommon.cryptRandom.getRange(1, 99);

						LessStdyRcd lessStdyRcd = new LessStdyRcd();
						lessStdyRcd.memNo = memNo;
						lessStdyRcd.level = level;
						lessStdyRcd.stdyNum = SCommon.cryptRandom.getRange(0, lessNum);
						lessStdyRcd.lessNum = lessNum;
						lessStdyRcd.cortNum = SCommon.cryptRandom.getRange(0, quesNum);
						lessStdyRcd.quesNum = quesNum;
						lessStdyRcdsList.get(lessStdyRcdsList.size() - 1).add(lessStdyRcd);
					}
				}
			}
		}
	}
}
