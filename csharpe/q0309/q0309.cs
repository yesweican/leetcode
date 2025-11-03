public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length == 0)
            return 0;

        int[] buy = new int[prices.Length];
        int[] sell = new int[prices.Length];
        int[] rest = new int[prices.Length];

        sell[0] = 0;
        buy[0] = -prices[0];
        rest[0] = 0;

        for(int i=1; i<prices.Length; i++)
        {
            //you do nothing after buying or buying after resting
            buy[i] = Math.Max(buy[i - 1], rest[i - 1] - prices[i]);
            //you could do nothing after selling or selling after buying
            sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);
            //or or or or or just doing nothing
            rest[i] = Math.Max(sell[i - 1], Math.Max(buy[i - 1], rest[i - 1]));
        }

        return sell[prices.Length-1];        
    }
}