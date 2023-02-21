package tests.charlotte.commons;

import java.io.File;

import charlotte.commons.SCommon;

public class Test0001 {
	public static void main(String[] args) {
		try {
			new Test0001().test01();
		}
		catch (Throwable e) {
			e.printStackTrace();
		}
	}

	private void test01() {
		//SCommon.searchDirectory(new File("C:/XXX"), false, f -> System.out.println(f.getAbsolutePath()));
		SCommon.searchDirectory(new File("C:/temp"), false, f -> System.out.println(f.getAbsolutePath()));
		SCommon.searchDirectory(new File("C:/home/画像"), true, f -> System.out.println(f.getAbsolutePath()));
	}
}