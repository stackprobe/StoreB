package tests.charlotte.commons;

import java.util.ArrayList;
import java.util.List;

public class Test0004 {
	public static void main(String[] args) {
		try {
			List<Double> curr = new ArrayList<Double>();
			double kitaichi = 0.0;

			curr.add(1.0);

			for (int n = 1; n <= 1000; n++) {
			//for (int n = 1; n <= 3000; n++) {
			//for (int n = 1; n <= 10000; n++) {
				List<Double> next = new ArrayList<Double>();

				next.add(0.0);

				for (int index = 0; index < curr.size(); index++) {
					double r = curr.get(index);
					double hr = r / 2.0;

					if (index == 0) {
						double kitaichiAdd = n * hr;
						kitaichi += kitaichiAdd;
						System.out.println(n + " <== " +
								String.format("%.9f", hr) + " , " +
								String.format("%.9f", kitaichi) + " , " +
								String.format("%.9f", kitaichiAdd));
					}
					else {
						next.set(index - 1, next.get(index - 1) + hr);
					}
					next.add(hr);
				}
				curr = next;
			}
		}
		catch (Throwable e) {
			e.printStackTrace();
		}
	}
}
