
# since 2010 it is possible define the type of parameter
def climbstair(n:int):
    if(n==2):
        return 2
    if(n==1):
        return 1
    return climbstair(n-1) + climbstair(n-2)

n=int(input("Stair count:"))
print("Total:" + str(climbstair(n)))