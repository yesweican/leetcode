using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public int MaxProfit(int[] prices) {
 
            StockBuySellEngine engine = new StockBuySellEngine();
            foreach (int price in prices)
            {
                engine.Process(price);
            }

                if (engine.BestPeriod != null)
                {
                    return engine.BestPeriod.Gain;
                }
                else
                {
                    return 0;
                }
    }
}

    public enum EngineStatus {NoProfitPeriod, OneProfitPeriod, MoreThanOnePeriod};


    public class StockBuySellEngine
    {
        public EngineStatus CurrentEngineStatus { get; set; }
        ArrayList historicalPeriods = new ArrayList();

        //public ProfitPeriod IncompletePeriod { get; set; }
        public ProfitPeriod PreviousBestPeriod { get; set; }
        public ProfitPeriod CurrentPeriod { get; set; }

        public StockBuySellEngine()
        {
            CurrentEngineStatus = EngineStatus.NoProfitPeriod;
            PreviousBestPeriod = null;
            CurrentPeriod = new ProfitPeriod();
        }

        public ProfitPeriod BestPeriod
        {
            get
            {
                if (CurrentEngineStatus == EngineStatus.NoProfitPeriod)
                {
                    if (CurrentPeriod.CurrentPeriodStatus == PeriodStatus.Profitable)
                    {
                        return CurrentPeriod;
                    }
                    else
                    {
                        return null;
                    }

                }

                if (CurrentPeriod.CurrentPeriodStatus == PeriodStatus.Profitable)
                {
                    if (CurrentPeriod.Gain > PreviousBestPeriod.Gain)
                            return CurrentPeriod;

                }
                return PreviousBestPeriod;
            }
        }

        public void Process(int newValue)
        {
            switch (CurrentEngineStatus)
            {
                case EngineStatus.NoProfitPeriod:
                    {
                        if (CurrentPeriod.Process(newValue) == PeriodStatus.Closed)
                        { 
                            //Refine further - Compare Before Override
                            //PreviousPeriod = CurrentPeriod;
                            historicalPeriods.Add(CurrentPeriod);
                            CurrentEngineStatus = EngineStatus.OneProfitPeriod;
                            PreviousBestPeriod = new ProfitPeriod() { PeriodLow = CurrentPeriod.PeriodLow, PeriodHigh = CurrentPeriod.PeriodHigh };
                            CurrentPeriod = new ProfitPeriod();
                            CurrentPeriod.Process(newValue);
                        };

                        break;
                    }
                case EngineStatus.OneProfitPeriod: 
                    {
                        if (CurrentPeriod.Process(newValue) == PeriodStatus.Closed)
                        {
                            //Refine further - Compare Before Override
                            if (PreviousBestPeriod.Gain < CurrentPeriod.Gain)
                            {
                                //replace previous best period 
                                PreviousBestPeriod = new ProfitPeriod() { PeriodLow = CurrentPeriod.PeriodLow, PeriodHigh = CurrentPeriod.PeriodHigh };
                            };
                            historicalPeriods.Add(CurrentPeriod);
                            CurrentEngineStatus = EngineStatus.MoreThanOnePeriod;
                            CurrentPeriod = new ProfitPeriod();
                            CurrentPeriod.Process(newValue);
                        };
                        break;
                    }
                case EngineStatus.MoreThanOnePeriod:
                    {
                        if (CurrentPeriod.Process(newValue) == PeriodStatus.Closed)
                        {
                            //Compare Before Override
                            //potentially keep a SecondBestPeriod
                            if (PreviousBestPeriod.Gain < CurrentPeriod.Gain)
                            {
                                //replace previous best period 
                                PreviousBestPeriod = new ProfitPeriod() { PeriodLow = CurrentPeriod.PeriodLow, PeriodHigh = CurrentPeriod.PeriodHigh };
                            };
                            historicalPeriods.Add(CurrentPeriod);
                            CurrentPeriod = new ProfitPeriod();
                            CurrentPeriod.Process(newValue);
                        };
                        break;
                    }

            }

        }
    }

    public enum PeriodStatus { Imcomplete, Profitable, Closed };
    public class ProfitPeriod
    {
        public ProfitPeriod()
        {
            PeriodLow = -1;
            PeriodHigh = -1;
            CurrentPeriodStatus = PeriodStatus.Imcomplete;
        }

        public PeriodStatus CurrentPeriodStatus
        {
            get;
            set;
        }
        public int PeriodLow
        {
            get;
            set;
        }

        public int PeriodHigh
        {
            get;
            set;
        }

        public int Gain
        {
            get
            {
                return PeriodHigh - PeriodLow;
            }
        }

        public PeriodStatus Process(int newValue)
        {
            switch (CurrentPeriodStatus)
            {
                case PeriodStatus.Imcomplete:
                    {
                        if (PeriodLow == -1)
                        {
                            PeriodLow = newValue;
                        }
                        else
                        {
                            if (newValue < PeriodLow)
                            {
                                PeriodLow = newValue;
                            }
                            else
                            {
                                CurrentPeriodStatus = PeriodStatus.Profitable;
                                PeriodHigh = newValue;
                            }
                        }

                        break;
                    }
                case PeriodStatus.Profitable:
                    {
                        if (newValue > PeriodHigh)
                        {
                            PeriodHigh = newValue;
                        }
                        else
                        {
                            if (newValue < PeriodLow)
                            {
                                CurrentPeriodStatus = PeriodStatus.Closed;
                            }
                        }
                        break;
                    }
                case PeriodStatus.Closed:
                    {
                        break;
                    }

            }
            return CurrentPeriodStatus;
        }
    }