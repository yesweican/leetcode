public class Solution {
    public string LargestNumber(int[] nums) {
        
        List<NumericString> list = new List<NumericString>();
        for(int i=0; i<nums.Length;i++)
        {
             list.Add(new NumericString(nums[i]));
        }
        list.Sort();//sort ascending
        //list.Reverse();
        
        StringBuilder builder = new StringBuilder();
        foreach (NumericString item in list)
        {
           builder.Append(item.StringValue);
        }
        
        String temp = builder.ToString().TrimStart(new Char[] { '0' } );
        return temp==""?"0":temp;
    }
    
    public class NumericString:IComparable<NumericString>
    {
        public string StringValue { get; set; }
        public int IntValue { get; set; }

        public NumericString(int n)
        {
            IntValue = n;
            StringValue = n.ToString();

        }

        public int CompareTo(NumericString obj)
        {
            string t1 = this.StringValue + obj.StringValue;
            string t2 = obj.StringValue + this.StringValue;

            return -String.Compare(t1, t2);

        }
    }
}