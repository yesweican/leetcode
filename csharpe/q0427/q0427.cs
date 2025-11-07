/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

public class Solution {
    int[][] data;
    public Node Construct(int[][] grid) {
        data = grid;
        int height = grid.Length;
        int width = grid[0].Length;

        return process(0,0, height-1, width-1); 
    }

    private Node process(int r0, int c0, int r1, int c1)
    {
        Node result = new Node();

        int countOne=0; int countZero=0;

        for(int r=r0; r<=r1; r++)
        {
            for(int c=c0; c<=c1; c++)
            {
                if(data[r][c]==1)
                    countOne++;
                if(data[r][c]==0)
                    countZero++;                
            }
        }

        if(countZero==0)
        {
            result.isLeaf = true;
            result.val = true;
            return result;
        }

        if(countOne==0)
        {
            result.isLeaf = true;
            result.val = false;
            return result;
        }

        //Node.isLeaf = false;
        int height2 = (r1-r0+1)/2;
        int width2 = (c1-c0+1)/2;

        Node node1 = process(r0,c0, r0+height2-1, c0+width2-1);
        Node node2 = process(r0+height2, c0, r1, c0+width2-1);
        Node node3 = process(r0, c0+width2, r0+height2-1, c1);
        Node node4 = process(r0+height2, c0+width2, r1, c1);

        result.topLeft = node1;
        result.bottomLeft = node2;
        result.topRight = node3;
        result.bottomRight = node4;

        return result;

    }

}