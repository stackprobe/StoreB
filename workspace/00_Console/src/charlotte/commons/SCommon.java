package charlotte.commons;

import java.io.File;
import java.security.SecureRandom;
import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;
import java.util.Queue;
import java.util.function.Consumer;

/**
 * 共通機能・便利機能はできるだけこのクラスに集約する。
 * @author mt
 *
 */
public class SCommon {

	public static RandomUnit cryptRandom = new RandomUnit(new SecureRandom());

	/**
	 * ディレクトリ内のディレクトリとファイルを検索する。
	 * @param targetDirectory 対象ディレクトリ
	 * @param allDirectories 配下のディレクトリ内も検索するか
	 * @return 発見したディレクトリとファイルの配列
	 */
	public static List<File> getFiles(File targetDirectory, boolean allDirectories) {
		final List<File> dest = new ArrayList<File>();
		searchDirectory(targetDirectory, allDirectories, f -> dest.add(f));
		return dest;
	}

	/**
	 * ディレクトリ内のディレクトリとファイルを検索する。
	 * @param targetDirectory 対象ディレクトリ
	 * @param allDirectories 配下のディレクトリ内も検索するか
	 * @param reaction 発見したディレクトリとファイルに対するリアクション
	 */
	public static void searchDirectory(File targetDirectory, boolean allDirectories, Consumer<File> reaction) {
		if (!targetDirectory.isDirectory()) {
			throw new Error();
		}

		Queue<File> q = new ArrayDeque<File>();
		q.add(targetDirectory);

		while (!q.isEmpty()) {
			for (File f : q.poll().listFiles()) {
				reaction.accept(f);

				if (allDirectories && f.isDirectory()) {
					q.add(f);
				}
			}
		}
	}

	// PRIMITIVE[] -> List<PRIMITIVE> ここから

	public static List<Boolean> toList(boolean[] arr) {
		List<Boolean> list = new ArrayList<Boolean>(arr.length);

		for (int index = 0; index < arr.length; index++) {
			list.add(arr[index]);
		}
		return list;
	}

	public static List<Byte> toList(byte[] arr) {
		List<Byte> list = new ArrayList<Byte>(arr.length);

		for (int index = 0; index < arr.length; index++) {
			list.add(arr[index]);
		}
		return list;
	}

	public static List<Character> toList(char[] arr) {
		List<Character> list = new ArrayList<Character>(arr.length);

		for (int index = 0; index < arr.length; index++) {
			list.add(arr[index]);
		}
		return list;
	}

	public static List<Short> toList(short[] arr) {
		List<Short> list = new ArrayList<Short>(arr.length);

		for (int index = 0; index < arr.length; index++) {
			list.add(arr[index]);
		}
		return list;
	}

	public static List<Integer> toList(int[] arr) {
		List<Integer> list = new ArrayList<Integer>(arr.length);

		for (int index = 0; index < arr.length; index++) {
			list.add(arr[index]);
		}
		return list;
	}

	public static List<Long> toList(long[] arr) {
		List<Long> list = new ArrayList<Long>(arr.length);

		for (int index = 0; index < arr.length; index++) {
			list.add(arr[index]);
		}
		return list;
	}

	public static List<Float> toList(float[] arr) {
		List<Float> list = new ArrayList<Float>(arr.length);

		for (int index = 0; index < arr.length; index++) {
			list.add(arr[index]);
		}
		return list;
	}

	public static List<Double> toList(double[] arr) {
		List<Double> list = new ArrayList<Double>(arr.length);

		for (int index = 0; index < arr.length; index++) {
			list.add(arr[index]);
		}
		return list;
	}

	// PRIMITIVE[] -> List<PRIMITIVE> ここまで

	// List<PRIMITIVE> -> PRIMITIVE[] ここから

	public static boolean[] toPrimitiveBooleanArray(List<Boolean> list) {
		boolean[] arr = new boolean[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static byte[] toPrimitiveByteArray(List<Byte> list) {
		byte[] arr = new byte[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static char[] toPrimitiveCharArray(List<Character> list) {
		char[] arr = new char[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static short[] toPrimitiveShortArray(List<Short> list) {
		short[] arr = new short[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static int[] toPrimitiveIntArray(List<Integer> list) {
		int[] arr = new int[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static long[] toPrimitiveLongArray(List<Long> list) {
		long[] arr = new long[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static float[] toPrimitiveFloatArray(List<Float> list) {
		float[] arr = new float[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static double[] toPrimitiveDoubleArray(List<Double> list) {
		double[] arr = new double[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	// List<PRIMITIVE> -> PRIMITIVE[] ここまで
}
