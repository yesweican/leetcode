using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q901
    {
        int[] Prices;
        int _Capacity;
        int _CurrentPos;
        int[] DP;//DP array could be called Span[]

        /// <summary>
        /// StockSpanner
        /// </summary>
        public q901()
        {
            _Capacity = 10000;
            Prices = new int[_Capacity];
            DP = new int[_Capacity];

            _CurrentPos = 0;

        }

        public int Next(int price)
        {
            Prices[_CurrentPos] = price;
            DP[_CurrentPos] = 1;

            if(_CurrentPos==0)
            {
                //Needed!!!!
                _CurrentPos++;
                return 1;
            }

            int temp = _CurrentPos-1;
            while((temp>=0) && (Prices[temp]<Prices[_CurrentPos]))
            {
                //how many valid span we could skipp over one leap at a time
                DP[_CurrentPos] += DP[temp];
                //temp move back forward until invalid
                temp -= DP[temp];
            }

            _CurrentPos++;
            return DP[_CurrentPos - 1];


        }
    }
}
