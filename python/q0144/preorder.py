# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None


result=[]

def preorderTravesal(root:TreeNode):
    current = root
    result.append(current.val)
    print(current.val)
    if(current.left is not None):
        preorderTravesal(current.left)
    if(current.right is not None):
        preorderTravesal(current.right)

# iterative implementation of inorder tree travesal
def preorderTravesal2(root:TreeNode):
    if(root is None):
        return []
    result=[]
    stack=[] #list as stack
    stack.append(root)
    while(len(stack)>0):
        node = stack.pop()
        print(node.val)
        result.append(node.val)

        if(node.right is not None):
            stack.append(node.right)
        if (node.left is not None):
            stack.append(node.left)

    return result



root = TreeNode(1)
root.left = TreeNode(2)
root.right = TreeNode(3)
root.left.left = TreeNode(4)
root.left.right = TreeNode(5)
preorderTravesal2(root)