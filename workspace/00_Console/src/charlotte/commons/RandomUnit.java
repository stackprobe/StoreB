package charlotte.commons;

import java.util.Random;

public class RandomUnit {
	private Random r;

	public RandomUnit(Random r) {
		this.r = r;
	}

	public void read(byte[] buff) {
		r.nextBytes(buff);
	}

	public byte[] getBytes(int size) {
		byte[] buff = new byte[size];
		read(buff);
		return buff;
	}

	public byte getByte() {
		return getBytes(1)[0];
	}

	public int getInt() {
		byte[] data = getBytes(4);
		int returnValue =
				(data[0] & 0xff) << 0 |
				(data[1] & 0xff) << 8 |
				(data[2] & 0xff) << 16 |
				(data[3] & 0xff) << 24;
		return returnValue;
	}

	public long getLong() {
		byte[] data = getBytes(8);
		long returnValue =
				(data[0] & 0xff) << 0 |
				(data[1] & 0xff) << 8 |
				(data[2] & 0xff) << 16 |
				(data[3] & 0xff) << 24 |
				(data[4] & 0xff) << 32 |
				(data[5] & 0xff) << 40 |
				(data[6] & 0xff) << 48 |
				(data[7] & 0xff) << 56;
		return returnValue;
	}

	public long getPositiveLong() {
		return getLong() & 0x7fffffffffffffffL;
	}

	public int getInt(int modulo) {
		if (modulo < 1) {
			throw new Error();
		}
		return (int)(getPositiveLong() % (long)modulo);
	}

	public int getRange(int minval, int maxval) {
		return getInt(maxval - minval + 1) + minval;
	}
}
