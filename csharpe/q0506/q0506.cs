public class Solution {
    public string[] FindRelativeRanks(int[] score) {
        PriorityQueue<int,int> queue = new PriorityQueue<int, int>();

        for(int i=0; i<score.Length; i++) {
            queue.Enqueue(score[i], -score[i]);
        }

        Dictionary<int, int> dict = new Dictionary<int, int>();
        for(int i=1; i<=score.Length; i++) {
            int sc = queue.Dequeue();
            dict.Add(sc, i);
        }

        List<string> result = new List<string>();
        for(int i=0; i<score.Length; i++) {
            int t = dict[score[i]];
            string s;
            switch(t) {
                case 1: s = "Gold Medal"; break;
                case 2: s = "Silver Medal"; break;
                case 3: s = "Bronze Medal"; break;
                default : s = t.ToString(); break;
            }
            result.Add(s);
        }

        return result.ToArray();
    }
}