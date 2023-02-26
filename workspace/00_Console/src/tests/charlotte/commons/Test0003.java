package tests.charlotte.commons;

import java.util.stream.Stream;

import charlotte.commons.SCommon;

public class Test0003 {
	public static void main(String[] args) {
		try {
			new Test0003().test01();
		}
		catch (Throwable e) {
			e.printStackTrace();
		}
	}

	private void test01() throws Exception {
		String TEST_CHRS = SCommon.DECIMAL + SCommon.ALPHA + SCommon.alpha;

		for (int testCnt = 0; testCnt < 1000; testCnt++) {
			String str = new String(SCommon.toPrimitiveCharArray(Stream
					.generate(() -> SCommon.cryptRandom.chooseOne(SCommon.toList(TEST_CHRS.toCharArray())))
					.limit(SCommon.cryptRandom.getInt(1000)).toList()));

			byte[] src = str.getBytes(SCommon.CHARSET_ASCII);
			byte[] mid = SCommon.compress(src);
			byte[] dest = SCommon.decompress(mid);

			if (SCommon.compare(SCommon.toList(src), SCommon.toList(dest), (a, b) -> (a.byteValue() & 0xff) - (b.byteValue() & 0xff)) != 0) {
				throw null;
			}
		}
		System.out.println("OK!");
	}
}
