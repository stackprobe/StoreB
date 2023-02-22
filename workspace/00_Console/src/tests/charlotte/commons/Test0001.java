package tests.charlotte.commons;

import java.io.File;
import java.util.stream.Collectors;

import charlotte.commons.SCommon;

public class Test0001 {
	public static void main(String[] args) {
		try {
			//new Test0001().test01();
			new Test0001().test02();
		}
		catch (Throwable e) {
			e.printStackTrace();
		}
	}

	private void test01() {
		SCommon.searchDirectory(new File("C:/temp"),
				true,
				//false,
				f -> System.out.println(f.getAbsolutePath()));
	}

	private void test02() {
		for (File f : SCommon.getFiles(new File("C:/temp"), true).stream().filter(f -> f.isFile()).collect(Collectors.toList())) {
			System.out.println("file: " + f);
		}
		for (File d : SCommon.getFiles(new File("C:/temp"), true).stream().filter(f -> f.isDirectory()).collect(Collectors.toList())) {
			System.out.println("directory: " + d);
		}
	}
}
