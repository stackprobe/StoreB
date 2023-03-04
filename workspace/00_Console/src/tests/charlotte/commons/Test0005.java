package tests.charlotte.commons;

import java.util.stream.Collectors;

import charlotte.commons.SCommon;

public class Test0005 {
	public static void main(String[] args) {
		try {
			test01();
		}
		catch (Throwable e) {
			e.printStackTrace();
		}
	}

	private static void test01() {
		final int TEST_COUNT = 3000000;
		final int GAME_MAX = 100;

		int[] winners = new int[GAME_MAX + 1];
		int[] winVals = new int[GAME_MAX + 1];

		for (int testCnt = 0; testCnt < TEST_COUNT; testCnt++) {
			if (testCnt % (TEST_COUNT / 100) == 0) { System.out.println(testCnt); } // cout

			int win = 0;
			int game = 0;

			while (game < GAME_MAX) {
				win += SCommon.cryptRandom.getReal1() < 0.5 ? 1 : -1;
				game++;

				if (win < 0) {
					break;
				}
			}
			if (win < 0) {
				winners[game]++;
			}
			else {
				winVals[win]++;
			}
		}

		SCommon.writeAllLines(
				"C:/temp/winners.csv",
				SCommon.toList(winners).stream().map(v -> "" + v).collect(Collectors.toList()),
				SCommon.CHARSET_ASCII
				);

		SCommon.writeAllLines(
				"C:/temp/winVals.csv",
				SCommon.toList(winVals).stream().map(v -> "" + v).collect(Collectors.toList()),
				SCommon.CHARSET_ASCII
				);
	}
}
