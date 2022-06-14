using System.Text;

namespace Fengweizhe
{
    class Sort
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入要排序的数字组, 用逗号隔开:");
            String line = Console.ReadLine();
            String[] arr = line.Split(",");
            List<int> list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Trim() == "") continue;
                try
                {
                    list.Add(int.Parse(arr[i]));
                }
                catch (Exception)
                {
                    continue;
                }
            }
            sort(list, 0, list.Count - 1);
            Console.WriteLine("快速排序后的结果如下:");
            StringBuilder sb = new StringBuilder();
            foreach (int i in list)
            {
                if (sb.Length == 0)
                    sb.Append(i.ToString());
                else
                    sb.Append(",").Append(i.ToString());
            }
            Console.WriteLine(sb.ToString());
        }

        public static void sort(List<int> list, int min, int max)
        {
            if (list.Count == 0) return;
            int key = list[min];// 取第一个值作为基准值
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
                sort(list, min, start - 1);
            }
            // 排序基数右边
            if (end < max)
            {
                sort(list, end + 1, max);
            }
        }
    }
}