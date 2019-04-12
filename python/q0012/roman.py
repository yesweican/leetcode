def intToRoman(num: int) -> str:
    liststr = []
    digits = [-1,-1,-1,-1]
    digits[3] = num % 10
    num = ((num-digits[3])/10)

    digits[2] = num % 10
    num = ((num-digits[2])/10)

    digits[1] = num % 10
    num = ((num-digits[1])/10)

    digits[0] = num % 10
    num = ((num-digits[0])/10)

    if (digits[0]==1):
        liststr.append("M")
    if (digits[0]==2):
        liststr.append("MM")
    if (digits[0]==3):
        liststr.append("MMM")
    if (digits[0]==4):
        liststr.append("MMMM")

    if (digits[1]==1):
        liststr.append("C")
    if (digits[1]==2):
        liststr.append("CC")
    if (digits[1]==3):
        liststr.append("CCC")
    if (digits[1]==4):
        liststr.append("CD")
    if (digits[1]==5):
        liststr.append("D")
    if (digits[1]==6):
        liststr.append("DC")
    if (digits[1]==7):
        liststr.append("DCC")
    if (digits[1]==8):
        liststr.append("DCCC")
    if (digits[1]==9):
        liststr.append("CM")

    if (digits[2]==1):
        liststr.append("X")
    if (digits[2]==2):
        liststr.append("XX")
    if (digits[2]==3):
        liststr.append("XXX")
    if (digits[2]==4):
        liststr.append("XL")
    if (digits[2]==5):
        liststr.append("L")
    if (digits[2]==6):
        liststr.append("LX")
    if (digits[2]==7):
        liststr.append("LXX")
    if (digits[2]==8):
        liststr.append("LXXX")
    if(digits[2]==9):
        liststr.append("XC")

    if (digits[3]==1):
        liststr.append("I")
    if (digits[3]==2):
        liststr.append("II")
    if (digits[3]==3):
        liststr.append("III")
    if (digits[3]==4):
        liststr.append("IV")
    if (digits[3]==5):
        liststr.append("V")
    if (digits[3]==6):
        liststr.append("VI")
    if (digits[3]==7):
        liststr.append("VII")
    if (digits[3]==8):
        liststr.append("VIII")
    if (digits[3]==9):
        liststr.append("IX")

    return "".join(liststr)

def romanToInt(self, s: str) -> int:
    pass

#print(intToRoman(3))

print(intToRoman(1994))