using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
	internal class CustomSort : Sorter
	{
		/// <summary>
		/// Class allowing the sorting of Order objects based on Deliver Date (most recent first) 
		/// using any sorting algorithm of your choice
		/// 
		/// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
		/// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
		/// 2. Any methods added to this class must be declared as private and called within the Sort() method
		/// </summary>
		public override List<Order> Sort(List<Order> unsortedOrderList)
		{
			if (unsortedOrderList == null || unsortedOrderList.Count <= 1)
				return new List<Order>(unsortedOrderList);

		
			List<Order> sortedList = new List<Order>(unsortedOrderList);
			sortedList.Sort((a, b) => b.deliverOn.CompareTo(a.deliverOn)); 
			return sortedList;
		}
	}
}