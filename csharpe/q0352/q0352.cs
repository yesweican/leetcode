public class SummaryRanges {
   public class IntervalComparer : IComparer<int[]>
   {
      ////Following method need to be public!!!
      public int Compare(int[] x, int[] y)
      {
          return  (x[0]-y[0])!=0?(x[0]-y[0]):(x[1]-y[1]);
      }
   }


    List<int[]> data;
    public SummaryRanges() {
        data = new List<int[]>();
    }
 
    public void AddNum(int value) {
        int[] temp = new int[2]{value, value};
        if(data.Count==0)
        {
            data.Add(temp);
        }
        else
        {
            int index = data.BinarySearch(temp, new IntervalComparer());

            if(index>=0)
                return;
            else
                index =  ~index;

            //if there were no IntervalPrior
            if(index==0)
            {
                if ((data[0][0] - 1) == value)
                    data[0][0] = value;
                else
                {
                    if((data[0][0]-1)>value)
                        data.Insert(0, temp);                    
                    //else data[0][0]==value
                    //do nothing
                }
                return;
            }

            int[] intervalPrior = data[index - 1];
            if (intervalPrior[1] >= value)
                    return;
            //if there were no IntervalBehind
            if(index==data.Count)
            {
                if ((intervalPrior[1] + 1) == value)
                    data[index - 1][1] = value;
                else
                    data.Add(temp);
                return;
            }

            int[] intervalBehind = data[index];

            if(intervalPrior[1]>=value || intervalBehind[0]==value)
                return;

            if((intervalPrior[1]+1)==value && value==(intervalBehind[0]-1))
            {
                data[index-1][1]=intervalBehind[1];
                data.RemoveAt(index);
            }
            else
            {
                bool processed = false;

                if((intervalPrior[1]+1)==value)
                {
                    data[index-1][1]=value;
                    processed=true;
                }
                
                if(value==(intervalBehind[0]-1))
                {
                    data[index][0]=value;
                    processed = true;
                }

                if(processed == false)
                {
                    data.Insert(index, temp);
                }
            }
        }
    }
    
    public int[][] GetIntervals() {
        return data.ToArray();
    }
}

/**
 * Your SummaryRanges object will be instantiated and called as such:
 * SummaryRanges obj = new SummaryRanges();
 * obj.AddNum(value);
 * int[][] param_2 = obj.GetIntervals();
 */