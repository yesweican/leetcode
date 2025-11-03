public class Solution {
    public int CompareVersion(string version1, string version2) {
        List<int>l1 = separate(version1);
        List<int>l2 = separate(version2);

        int current = 0;
        int n1 = l1.Count;
        int n2 = l2.Count;

        while(current<n1 && current<n2) {
            if (l1[current]<l2[current])
              return -1;
            
           if (l1[current]>l2[current])
              return 1;
            current++;      
        }

        if(current<n1){
            while(current<n1) {
                if(l1[current]>0)
                    return 1;
                current++;                
            }

        }

        if(current<n2) {
            while(current<n2) {
                if(l2[current]>0)
                    return -1; 
                current++;               
            }
        }

        return 0;
        
    }

    private List<int> separate(string s) {
        List<int> result = new List<int>();

        char[] sc= new char[] {'.'};

        string[] versions = s.Split(sc);
        int temp;

        for(int i=0; i<versions.Length; i++) {
            if(Int32.TryParse(versions[i], out temp)) {
                result.Add(temp);
            } else {
                break;
            }
        }
         return result; 
    }
}