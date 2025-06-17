using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{

	/// <summary>
	/// Class allowing the sorting of Order objects based on Date Placed (most recent first) using Merge Sort
	/// 
	/// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
	/// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
	/// 2. Any methods added to this class must be declared as private and called within the Sort() method
	/// </summary>
	internal class MergeSort : Sorter
	{
		public override List<Order> Sort(List<Order> unsortedOrderList)
		{
			if (unsortedOrderList == null || unsortedOrderList.Count <= 1)
				return new List<Order>(unsortedOrderList);

			List<Order> sortedList = new List<Order>(unsortedOrderList);
			MergeSortRecursive(sortedList, 0, sortedList.Count - 1);
			return sortedList;
		}

		private void MergeSortRecursive(List<Order> list, int left, int right)
		{
			if (left < right)
			{
				int mid = (left + right) / 2;
				MergeSortRecursive(list, left, mid);
				MergeSortRecursive(list, mid + 1, right);
				Merge(list, left, mid, right);
			}
		}

		private void Merge(List<Order> list, int left, int mid, int right)
		{
			List<Order> temp = new List<Order>();
			int i = left, j = mid + 1;

			while (i <= mid && j <= right)
			{
				if (list[i].placedOn >= list[j].placedOn)
				{
					temp.Add(list[i]);
					i++;
				}
				else
				{
					temp.Add(list[j]);
					j++;
				}
			}

			while (i <= mid)
			{
				temp.Add(list[i]);
				i++;
			}

			while (j <= right)
			{
				temp.Add(list[j]);
				j++;
			}

			for (int k = 0; k < temp.Count; k++)
			{
				list[left + k] = temp[k];
			}
		}
	}
}