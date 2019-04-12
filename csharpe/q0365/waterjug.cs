using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public bool CanMeasureWater(int x, int y, int z) {
             BucketEngine engine = new BucketEngine(x, y, z);
             return engine.Process();       
    }
}

    public class BucketEngine
    {
        public    ArrayList PreviousStatuses = new ArrayList();
        private int BucketASize, BucketBSize, TargetSize;

        public BucketEngine(int a, int b, int c)
        {
            BucketASize = a > b? a: b;
            BucketBSize = a > b? b: a;
            TargetSize = c;
        }

        public bool Process()
        {
            BucketsStatus initialBucketStatus = new BucketsStatus();
            ArrayList operationsX = VerityStatusIsNew(initialBucketStatus);
            return Explore(operationsX, 1);
        }

        public bool Explore(ArrayList potentialtransitions, int level)
        {
            ArrayList newPotentialTransitions = new ArrayList();

            foreach (Transition tran in potentialtransitions)
            {
                BucketsStatus temp = (BucketsStatus)tran.CurrentStatus.Clone();
                switch (tran.operation)
                {
                    case BucketOperations.FullA:
                        //get new status
                        temp.BucketAWater = BucketASize;
                        break;
                    case BucketOperations.EmptyA:
                        //get new status
                        temp.BucketAWater = 0;
                        break;
                    case BucketOperations.FullB:
                        //get new status
                        temp.BucketBWater = BucketBSize;
                        break;
                    case BucketOperations.EmptyB:
                        //get new status
                        temp.BucketBWater = 0;
                        break;
                    case BucketOperations.AtoB:
                        //get new status
                        if ((temp.BucketAWater + temp.BucketBWater) >= BucketBSize)
                        {
                            //total must be cosistent
                            int sum = temp.BucketAWater + temp.BucketBWater;
                            temp.BucketBWater = BucketBSize; temp.BucketAWater = sum - BucketBSize;
                        }
                        else
                        {
                            temp.BucketBWater = temp.BucketAWater + temp.BucketBWater; temp.BucketAWater = 0;
                        }

                        //Successful?
                        if (temp.BucketAWater == TargetSize )
                        {
                            //success   
                            return true;
                        }
                        break;
                    case BucketOperations.BtoA:
                        //get new status
                        if ((temp.BucketAWater + temp.BucketBWater) >= BucketASize)
                        {
                            //total must be cosistent
                            int sum = temp.BucketAWater + temp.BucketBWater;
                            temp.BucketAWater = BucketASize; temp.BucketBWater = sum - BucketASize;
                        }
                        else
                        {
                            temp.BucketAWater = temp.BucketAWater + temp.BucketBWater; temp.BucketBWater = 0;
                        }

                        //Successful?
                        if (temp.BucketAWater == TargetSize)
                        {
                           //Success                          
                            return true;
                        }
                        break;
                }
                
                if(temp.BucketAWater+temp.BucketBWater==TargetSize)
                            return true; 

                //Console.WriteLine("BucketA{0}: BucketB{1}", temp.BucketAWater, temp.BucketBWater);

                //verify it exist or not and 
                //if new generate all its next transitions
                foreach (Transition t in VerityStatusIsNew(temp))
                {
                    newPotentialTransitions.Add(t);
                }
            }

            if (newPotentialTransitions.Count == 0)
                return false;
            else
                return Explore(newPotentialTransitions, level + 1) ;
        }

        ArrayList VerityStatusIsNew(BucketsStatus status)
        {
            bool IsNewStatus = true;
            ArrayList results = new ArrayList();

            if (PreviousStatuses.Count > 0)
            {
                foreach (BucketsStatus s in PreviousStatuses)
                {
                    if ((s.BucketAWater == status.BucketAWater) && (s.BucketBWater == status.BucketBWater))
                    {
                        //already existed
                        IsNewStatus = false; break;
                    }
                }
            }

            if (IsNewStatus)
            {
                Transition transation1 = new Transition() { CurrentStatus = status, operation = BucketOperations.FullA };
                Transition transation2 = new Transition() { CurrentStatus = status, operation = BucketOperations.EmptyA };
                Transition transation3 = new Transition() { CurrentStatus = status, operation = BucketOperations.FullB };
                Transition transation4 = new Transition() { CurrentStatus = status, operation = BucketOperations.EmptyB };
                Transition transation5 = new Transition() { CurrentStatus = status, operation = BucketOperations.AtoB };
                Transition transation6 = new Transition() { CurrentStatus = status, operation = BucketOperations.BtoA };

                results.Add(transation1);
                results.Add(transation2);
                results.Add(transation3);
                results.Add(transation4);
                results.Add(transation5);
                results.Add(transation6);

                PreviousStatuses.Add(status);
            }

            return results;
        }
    }

    public class BucketsStatus: ICloneable
    {
        public int BucketAWater { get; set; }
        public int BucketBWater { get; set; }

        public BucketsStatus()
        {
            BucketAWater = 0;
            BucketBWater = 0;
        }

        public object Clone()
        {
            return new BucketsStatus() { BucketAWater = this.BucketAWater, BucketBWater = this.BucketBWater };
        }
    }
    
    public enum BucketOperations { FullA, EmptyA, FullB, EmptyB, AtoB, BtoA }
    public class Transition
    {
        public BucketsStatus CurrentStatus { get; set; }
        public BucketOperations operation { get; set; }
    }