# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

def levelTravesal(root:TreeNode):
    if(root is None):
        return []
    result=[]
    queue=[] #list as stack
    queue.append(root)
    while(len(queue)>0):
        node = queue[0]
        print(node.val)
        result.append(node.val)

        if (node.left is not None):
            queue.append(node.left)
        if(node.right is not None):
            queue.append(node.right)
        del queue[0]
    return result

root = TreeNode(1)
root.left = TreeNode(2)
root.right = TreeNode(3)
root.left.left = TreeNode(4)
root.left.right = TreeNode(5)
levelTravesal(root)