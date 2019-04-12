# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None


result=[]
def inorderTravesal(root:TreeNode):
    if(root.left!=None):
        inorderTravesal(root.left)
    result.append(root.val)
    if(root.right!=None):
        inorderTravesal(root.right)

# iterative implementation of inorder tree travesal
def inorderTravesal2(root:TreeNode):
    result=[]
    current =  root
    s=[] #list as stack
    done = 0
    while(not done):
        if(current is not None):
            s.append(current)
            current = current.left
        else:#back track
            if(len(s)>0):
                current = s.pop()
                print(current.val)
                result.append(current.val)
                current = current.right
            else:
                done = 1
    return result


root = TreeNode(1)
root.left = TreeNode(2)
root.right = TreeNode(3)
root.left.left = TreeNode(4)
root.left.right = TreeNode(5)
inorderTravesal2(root)



