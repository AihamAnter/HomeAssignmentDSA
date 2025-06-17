using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
	/// <summary>
	/// Class allowing the sorting of Order objects based on based on Order ID (ascending order) 
	/// using Quick Sort where the pivot is the left-most element
	/// 
	/// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
	/// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
	/// 2. Any methods added to this class must be declared as private and called within the Sort() method
	/// </summary>
	internal class QuickSort : Sorter
	{
		public override List<Order> Sort(List<Order> unsortedOrderList)
		{
			if (unsortedOrderList == null || unsortedOrderList.Count <= 1)
				return new List<Order>(unsortedOrderList);

			List<Order> sortedList = new List<Order>(unsortedOrderList);
			QuickSortRecursive(sortedList, 0, sortedList.Count - 1);
			return sortedList;
		}

		private void QuickSortRecursive(List<Order> list, int low, int high)
		{
			if (low < high)
			{
				int pivotIndex = Partition(list, low, high);
				QuickSortRecursive(list, low, pivotIndex - 1);
				QuickSortRecursive(list, pivotIndex + 1, high);
			}
		}

		private int Partition(List<Order> list, int low, int high)
		{
			Order pivot = list[low];
			int i = low;
			int j = high;

			while (i < j)
			{
				while (i <= high && list[i].ID.CompareTo(pivot.ID) <= 0)
					i++;
				while (j >= low && list[j].ID.CompareTo(pivot.ID) > 0)
					j--;

				if (i < j)
					Swap(list, i, j);
			}

			Swap(list, low, j);
			return j;
		}

		private void Swap(List<Order> list, int i, int j)
		{
			Order temp = list[i];
			list[i] = list[j];
			list[j] = temp;
		}
	}
}