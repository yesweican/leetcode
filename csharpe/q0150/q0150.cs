public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int>stack = new Stack<int>();
        int a;
        int b;

        foreach(var t in tokens)
        {
            switch(t)
            {
            case "+": 
                a=stack.Pop();
                b=stack.Pop();
                stack.Push(a+b);
                break;
            case "/": 
                a=stack.Pop();
                b=stack.Pop();
                stack.Push(b/a);
                break;
            case "*": 
                a=stack.Pop();
                b=stack.Pop();
                stack.Push(a*b);
                break;
            case "-": 
                a=stack.Pop();
                b=stack.Pop();
                stack.Push(b-a);
                break;
            default:
                if(Int32.TryParse(t, out int temp))
                {
                    stack.Push(temp);
                }
                break;                
            }
        }

        if (stack.Count>0)
          return stack.Pop();

        return 0;
    }
}