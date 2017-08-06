namespace Codepractice.Array
{
    public class Timestamp
    {
        public int ArrivalTime { get; set; }

        public int DepartureTime { get; set; }
    }
    public class Sorting
    {
        public int count;

        public Sorting()
        {
            this.count = 0;
        }
        public void quicksort(Timestamp[] input, int low, int high)
        {
            int pivot_loc = 0;
            // static int refcount = 0;
            if (low < high)
            {
                pivot_loc = partition(input, low, high);
                quicksort(input, low, pivot_loc - 1);
                quicksort(input, pivot_loc + 1, high);
            }
            else
                return;
        }

        private int partition(Timestamp[] input, int low, int high)
        {
            int pivot = input[high].ArrivalTime;
            int i = low;

            for (int j = low; j <= high - 1; j++)
            {
                if (input[j].ArrivalTime < pivot)
                {
                    
                    swap(input, i, j);
                    i++;
                }
            }
            if(input[i].ArrivalTime > pivot)
            swap(input, i, high);
            return i;
        }



        private void swap(Timestamp[] ar, int a, int b)
        {
            var temp = ar[a];
            ar[a] = ar[b];
            ar[b] = temp;
        }
    }

    public class TimeIntervel
    {
        public Timestamp[] timearray;

        public Sorting sortingobj = new Sorting();

        public void PopulateTimeStamp()
        {
            timearray = new Timestamp[]
            {
                new Timestamp {ArrivalTime = 7, DepartureTime = 8},
                new Timestamp {ArrivalTime = 8, DepartureTime = 10},
                new Timestamp {ArrivalTime = 6, DepartureTime = 9},
                new Timestamp {ArrivalTime = 10, DepartureTime = 13},
                new Timestamp {ArrivalTime = 14, DepartureTime = 18},
                new Timestamp {ArrivalTime = 12, DepartureTime = 14},
                new Timestamp {ArrivalTime = 9, DepartureTime = 11},
                new Timestamp {ArrivalTime = 13, DepartureTime = 17},

            };
        }

        public int FindIntersectingInterverl()
        {
            sortingobj.quicksort(timearray, 0, timearray.Length - 1);
            int max = int.MinValue;
            for (int i = 0; i < timearray.Length; i++)
            {
                int floorindex = BinarySearch(timearray, 0, timearray.Length-1, timearray[i].DepartureTime);
                max = floorindex - i > max ? floorindex - i : max;
            }
            return max;
        }

        public int BinarySearch(Timestamp[] arr, int low, int high, int val)
        {
            if (low > high)
                return -1;
            int mid = low + (high - low) / 2;

            if (arr[mid].ArrivalTime <= val && val <= arr[mid + 1 > high ? high : mid + 1].ArrivalTime)
                return mid;
            else if (arr[mid].ArrivalTime > val)
                return BinarySearch(arr, low, mid - 1, val);
            else
                return BinarySearch(arr, mid + 1, high, val);
        }
    }
}
