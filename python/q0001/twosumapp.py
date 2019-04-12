def twoSum(nums, target):
    previousnums = []
    for i in range(0, len(nums)-1):
        missing = target - nums[i]
        try:
            if(previousnums.index(missing)):
                return print(str(missing) + "+" + str(nums[i]))
        except ValueError:
            print("-")
        previousnums.append(nums[i])
    return print("not possible")

numdata = [1, 3, 4, 7, 6, 2]
twoSum(numdata, 11)


