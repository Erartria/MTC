using System.Collections.Generic;

namespace Task4
{
    public static class ListExtension
    {
        /// <summary>
        /// Вставка в отсортированный List
        /// </summary>
        /// <param name="list">Отсортированный List</param>
        /// <param name="element">Элемент для вставки</param>
        public static void InsertInCorrectPosition(this List<int> list, int element)
        {
            int start = 0;
            int end = list.Count - 1;
            int mid = (start + end) / 2;
            int insertionPos = 0;
            
            //Бинарный поиск
            while (start <= end)
            {
                if (list[mid] < element)
                {
                    start = mid + 1;
                    insertionPos = end;
                } else if (list[mid] > element)
                {
                    end = mid - 1;
                    insertionPos = mid;
                }
                else
                {
                    insertionPos = mid;
                    break;
                }
                mid = (start + end) / 2;
            }
            
            list.Insert(insertionPos, element);
        }
    }
}