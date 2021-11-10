using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    public static class ListExtension
    {
        /// <summary>
        /// Вставка в отсортированный List
        /// </summary>
        /// <param name="list">Отсортированный List</param>
        /// <param name="element">Элемент для вставки</param>
        public static void InsertionSort(this List<int> list)
        {
            if (list.Count == 1)
            {
                return;
            }
            int val = list[^1];
            bool flag = true;
            for (int j = list.Count - 2; j >= 0 && flag;) {
                if (val < list[j]) {
                    list[j + 1] = list[j];
                    j--;
                    list[j + 1] = val;
                }
                else flag = false;
            }
        }
    }
}