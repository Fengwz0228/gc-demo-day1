using System.Text;

namespace gc_demo_day1
{
    public static class MySort
    {
        public static void Main()
        {
            Console.WriteLine("请输入要排序的数字组, 用逗号隔开:");
            string inputStr = GetInputStrFromConsole();
            List<int> list = GetListByInputStr(inputStr);
            QuickSort(list, 0, list.Count - 1);
            Console.WriteLine("快速排序后的结果如下:");
            Console.WriteLine(string.Join(',', list));
        }

        private static string GetInputStrFromConsole()
        {
            string inputStr = "";
            do
            {
                var line = Console.ReadLine();
                if (null != line)
                {
                    inputStr = line;
                }
                else
                {
                    Console.WriteLine("请重新输入");
                }
            } while (inputStr == "");

            return inputStr;
        }

        private static List<int> GetListByInputStr(string inputStr)
        {
            var arr = inputStr.Split(",");
            List<int> list = new();
            foreach (var item in arr)
            {
                try
                {
                    list.Add(int.Parse(item));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return list;
        }

        private static void QuickSort(List<int> list, int min, int max)
        {
            if (list.Count == 0)
            {
                return;
            }

            int key = list[min]; // 取第一个值作为基准值
            int start = min; // 从左向右遍历的指针
            int end = max; // 从右向左遍历的指针 
            // 当左右指针不相遇
            while (end > start)
            {
                // 从右向左找 找到小于基准值的
                while (end > start && list[end] >= key)
                {
                    end--;
                }

                // 交换
                if (key > list[end])
                {
                    int temp = list[end];
                    list[end] = list[start];
                    list[start] = temp;
                }

                // 从左向右找，找到大于基准值的
                while (end > start && list[start] <= key)
                {
                    start++;
                }

                if (key < list[start])
                {
                    int temp = list[start];
                    list[start] = list[end];
                    list[end] = temp;
                }
            }

            // 此时基数的左边全小于基数， 基数的右边全大于基数
            // 排序基数左边
            if (start > min)
            {
                QuickSort(list, min, start - 1);
            }

            // 排序基数右边
            if (end < max)
            {
                QuickSort(list, end + 1, max);
            }
        }
    }
}