def isValid(s: str) -> bool:
    buffer = []

    for i in range(len(s)):
        c = s[i]
        buffercount=len(buffer)
        if(c=="("):
            buffer.append("(")
        if(c=="{"):
            buffer.append("{")
        if(c=="["):
            buffer.append("[")
        if(c==")"):
            if(buffercount==0):
                return False
            else:
                if(buffer[buffercount-1]=="("):
                    buffer.pop()
                else:
                    return False
        if(c=="}"):
            if(buffercount==0):
                return False
            else:
                if(buffer[buffercount-1]=="{"):
                    buffer.pop()
                else:
                    return False
        if(c=="]"):
            if(buffercount==0):
                return False
            else:
                if(buffer[buffercount-1]=="["):
                    buffer.pop()
                else:
                    return False
    if(len(buffer)>0):
        return False
    else:
        return True

#buggy solution
def isValid2(s: str) -> bool:
    lpcount1 = 0
    lpcount2 = 0
    lpcount3 = 0

    for i in range(len(s)):
        c = s[i]
        if (c == "("):
            lpcount1 += 1
        if (c == "{"):
            lpcount2 += 1
        if (c == "["):
            lpcount3 += 1
        if (c == ")"):
            if (lpcount1 == 0):
                return False
            else:
                lpcount1 -= 1;
        if (c == "}"):
            if (lpcount2 == 0):
                return False
            else:
                lpcount2 -= 1;
        if (c == "]"):
            if (lpcount3 == 0):
                return False
            else:
                lpcount3 -= 1;
    if (lpcount1 > 0 or lpcount2 > 0 or lpcount3 > 0):
        return False
    else:
        return True


if(isValid("((()))")):
    print("First test passed")
if(not isValid("())")):
    print("Second test passed")
if(not isValid("((())")):
    print("Third test passed")
if (isValid("(())()")):
    print("Fourth test passed")


