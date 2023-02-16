package charlotte.commons;

import java.util.ArrayList;
import java.util.List;

/**
 * 共通機能・便利機能はできるだけこのクラスに集約する。
 * @author mt
 *
 */
public class SCommon {

	// TODO
	// TODO
	// TODO

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

	public static boolean[] toBooleanArray(List<Boolean> list) {
		boolean[] arr = new boolean[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static byte[] toByteArray(List<Byte> list) {
		byte[] arr = new byte[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static char[] toCharArray(List<Character> list) {
		char[] arr = new char[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static short[] toShortArray(List<Short> list) {
		short[] arr = new short[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static int[] toIntArray(List<Integer> list) {
		int[] arr = new int[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static long[] toLongArray(List<Long> list) {
		long[] arr = new long[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static float[] toFloatArray(List<Float> list) {
		float[] arr = new float[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	public static double[] toDoubleArray(List<Double> list) {
		double[] arr = new double[list.size()];

		for (int index = 0; index < list.size(); index++) {
			arr[index] = list.get(index);
		}
		return arr;
	}

	// List<PRIMITIVE> -> PRIMITIVE[] ここまで
}
