public class Solution {
    public bool IsValid(string s) {
        char[] openParentheses = new char[] { '(', '{', '[' };
        char[] closeParentheses = new char[] { ')', '}', ']' };      
        
        
            OpenParenthesesStack stack = new OpenParenthesesStack();
            char temp;

            char[] data = s.ToCharArray();

            for (int i=0; i < data.Count(); i++)
            {
                if (openParentheses.Contains(data[i]))
                {
                    stack.Push(data[i]);
                }

                if (closeParentheses.Contains(data[i]))
                {
                    Console.WriteLine("{0}", data[i]);
                    temp=stack.Peek();
                    switch (data[i])
                    {
                        case ')':
                            if (temp != '(')
                                return false;
                            else
                                stack.Pop();
                            break;
                        case '}': 
                            if (temp != '{')
                                return false;
                            else
                                stack.Pop();                           
                            break;
                        case ']': 
                            if (temp != '[')
                                return false;
                            else
                                stack.Pop();                            
                            break;
                    }//end of switch
                }//end of if
            }//end of for

            if (stack.IsStackEmpty)
                return true;
            else
                return false;        
        
    }
}

    public class OpenParenthesesStack
    {
        char[] _stackdata = new char[10000];
        int _currentTop;

        public OpenParenthesesStack()
        {
            _currentTop = -1;
        }

        public int maxCapacity
        {
            get
            {
                return 10000;
            }
        }

        public bool Push(char c)
        {
            if(_currentTop<(maxCapacity-1))
            {
                _stackdata[_currentTop + 1] = c;
                _currentTop++;
                return true;
            }
            else
            {
                //reached capacity push failed
                return false;
            }

        }

        public char Pop()
        {
            if (_currentTop >= 0)
            {
                char temp = _stackdata[_currentTop];
                _currentTop--;
                return temp;
            }
            else
            {
                return '\0';
            }
        }

        public char Peek()
        {
            if (_currentTop >= 0)
                return _stackdata[_currentTop];
            else
                return '\0';
        }

        public bool IsStackEmpty
        {
            get
            {
                return _currentTop < 0;
            }
        }
    }