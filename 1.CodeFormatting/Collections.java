import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.ListIterator;
import java.util.RandomAccess;

public class Collections {
	
	// Suppresses default constructor, ensuring non-instantiability.
	private Collections() {}

	// Algorithms
	private static final int BINARYSEARCH_THRESHOLD = 5000;
	private static final int REVERSE_THRESHOLD = 18;
	private static final int SHUFFLE_THRESHOLD = 5;
	private static final int FILL_THRESHOLD = 25;
	private static final int ROTATE_THRESHOLD = 100;
	private static final int COPY_THRESHOLD = 10;
	private static final int REPLACEALL_THRESHOLD = 11;
	private static final int INDEXOFSUBLIST_THRESHOLD = 35;

	@SuppressWarnings("unchecked")
	public static <T extends Comparable<? super T>> void sort(final List<T>list) {
		final Object[] a = list.toArray();
		Arrays.sort(a);
		final ListIterator<T> i = list.listIterator();
		
		for (int j = 0; j < a.length; j++) {
			i.next();
			i.set((T) a[j]);
		}
	}

	@SuppressWarnings({"unchecked", "rawtypes"})
	public static <T> void sort(final List<T>list, final Comparator<? super T> c) {
		final Object[] a = list.toArray();
		Arrays.sort(a, (Comparator) c);
		final ListIterator<T> i = list.listIterator();

		for (int j = 0; j < a.length; j++) {
			i.next();
			i.set((T) a[j]);
		}
	}

	public static <T> int binarySearch(final List<? extends Comparable<? super T>> list, final T key) {		
		if (list instanceof RandomAccess || list.size() < BINARYSEARCH_THRESHOLD) {
			return Collections.indexedBinarySearch(list, key);
		} else {
			return Collections.iteratorBinarySearch(list, key);
		}

	}

	private static <T> int indexedBinarySearch(final List<? extends Comparable<? super T>> list, final T key) {		
		int low = 0;
		int high = list.size() - 1;

		while (low <= high) {
			final int mid = (low + high) >>> 1;
			final Comparable<? super T> midVal = list.get(mid);
			final int str = midVal.compareTo(key);

			if (str < 0) {
				low = mid + 1;
			} else if (str > 0) {
				high = mid - 1;
			} else {
				return mid; // key found
			}
		}

		return -(low + 1); // key not found
	}

	private static <T> int iteratorBinarySearch(final List<? extends Comparable<? super T>> list, final T key) {
		int low = 0;
		int high = list.size() - 1;
		final ListIterator<? extends Comparable<? super T>> i = list.listIterator();

		while (low <= high) {
			final int mid = (low + high) >>> 1;
			final Comparable<? super T> midVal = get(i, mid);
			final int str = midVal.compareTo(key);

			if (str < 0) {
				low = mid + 1;
			} else if (str > 0) {
				high = mid - 1;
			} else {
				return mid; // key found
			}
		}

		return -(low + 1); // key not found
	}

	private static <T> T get(final ListIterator<? extends T> i, final int index) {
		T obj = null;
		int pos = i.nextIndex();

		if (pos <= index) {
			do {
				obj = i.next();
			} while (pos++ < index);
		} else {
			do {
				obj = i.previous();
			} while (--pos > index);

		}
		
		return obj;
	}
}
