using System;

/// <summary>
/// Binary Tree vs Binary Search Tree
/// Typically don't use binary tree... instead we need to use a binary search tree in which
/// Left node is less than parent  and right node is greater than its parent
/// Binary Search Tree is a logical structure (abstract data type) - so it can be implemented in different ways
/// Balanced vs unbalanced
//like all right nodes instead of left and right nodes evenly distributed

//height
// 2^h-1 = n -> h = log(n+1) -> O logn)
//      O     Level 0
//     / \
//    O   O   Level 1
//   /\   /\
//  O  O O  O Level 2
//time complexity for delete and insert are also log n because essentially they are finding a node 
//and then adding constant time to do the operation so we can forget about the added constant time

//Data structures that use BinarySearchTree in their implementation are the C# sortedDictionary, Java Treemap and the C++ set class
//Also the heep is an implementation of a Binary Search Tree
/// </summary>
namespace BinaryTreeExample
{
    public class BinaryTree
    {
        private TreeNode root;
        public TreeNode Root
        {
            get { return root; }
        }


        //O(Log n)
        public TreeNode Find(int data)
        {
            //if the root is not null then we call the find method on the root
            if (root != null)
            {
                // call node method Find
                return root.Find(data);
            }
            else
            {//the root is null so we return null, nothing to find
                return null;
            }
        }

        //O(Log n)
        public TreeNode FindRecursive(int data)
        {
            //if the root is not null then we call the recursive find method on the root
            if (root != null)
            {
                //call Node Method FindRecursive
                return root.FindRecursive(data);
            }
            else
            {//the root is null so we return null, nothing to find
                return null;
            }

        }

        //O(Log n)
        public void Insert(int data)
        {
            //if the root is not null then we call the Insert method on the root node
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {//if the root is null then we set the root to be a new node based on the data passed in
                root = new TreeNode(data);
            }
        }

        //O(Log n)
        public void Remove(int data)
        {
            //Set the current and parent node to root, so when we remove we can remove using the parents reference
            TreeNode current = root;
            TreeNode parent = root;
            bool isLeftChild = false;//keeps track of which child of parent should be removed

            //empty tree
            if (current == null)
            {//nothing to be removed, end method
                return;
            }

            //Find the Node
            //loop through until node is not found or if we found the node with matching data
            while (current != null && current.Data != data)
            {
                //set current node to be new parent reference, then we look at its children
                parent = current;

                //if the data we are looking for is less than the current node then we look at its left child
                if (data < current.Data)
                {
                    current = current.LeftNode;
                    isLeftChild = true;//Set the variable to determin which child we are looking at
                }
                else
                {//Otherwise we look at its right child
                    current = current.RightNode;
                    isLeftChild = false;//Set the variable to determin which child we are looking at
                }
            }

            //if the node is not found nothing to delete just return
            if (current == null)
            {
                return;
            }

            //We found a Leaf node aka no children
            if (current.RightNode == null && current.LeftNode == null)
            {
                //The root doesn't have parent to check what child it is,so just set to null
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    //When not the root node
                    //see which child of the parent should be deleted
                    if (isLeftChild)
                    {
                        //remove reference to left child node
                        parent.LeftNode = null;
                    }
                    else
                    {   //remove reference to right child node
                        parent.RightNode = null;
                    }
                }
            }
            else if (current.RightNode == null) //current only has left child, so we set the parents node child to be this nodes left child
            {
                //If the current node is the root then we just set root to Left child node
                if (current == root)
                {
                    root = current.LeftNode;
                }
                else
                {
                    //see which child of the parent should be deleted
                    if (isLeftChild)//is this the right child or left child
                    {
                        //current is left child so we set the left node of the parent to the current nodes left child
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                    {   //current is right child so we set the right node of the parent to the current nodes left child
                        parent.RightNode = current.LeftNode;
                    }
                }
            }else if(current.LeftNode == null) //current only has right child, so we set the parents node child to be this nodes right child
            {
                //If the current node is the root then we just set root to Right child node
                if (current == root)
                {
                    root = current.RightNode;
                }
                else
                {
                    //see which child of the parent should be deleted
                    if (isLeftChild)
                    {   //current is left child so we set the left node of the parent to the current nodes right child
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {   //current is right child so we set the right node of the parent to the current nodes right child
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            else//Current Node has both a left and a right child
            {
                //When both child nodes exist we can go to the right node and then find the leaf node of the left child as this will be the least number
                //that is greater than the current node. It may have right child, so the right child would become..left child of the parent of this leaf aka successer node

                //Find the successor node aka least greater node
                TreeNode successor = GetSuccessor(current);
                //if the current node is the root node then the new root is the successor node
                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {//if this is the left child set the parents left child node as the successor node
                    parent.LeftNode = successor;
                }
                else
                {//if this is the right child set the parents right child node as the successor node
                    parent.RightNode = successor;
                }

            }

        }

        private TreeNode GetSuccessor(TreeNode node)
        {
            TreeNode parentOfSuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.RightNode;

            //starting at the right child we go down every left child node
            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftNode;// go to next left node
            }
            //if the succesor is not just the right node then
            if (successor != node.RightNode)
            {
                //set the Left node on the parent node of the succesor node to the right child node of the successor in case it has one
                parentOfSuccessor.LeftNode = successor.RightNode;
                //attach the right child node of the node being deleted to the successors right node
                successor.RightNode = node.RightNode;
            }
            //attach the left child node of the node being deleted to the successors leftnode node
            successor.LeftNode = node.LeftNode;

            return successor;
        }

        //O(Log n) Mark Node as deleted
        public void SoftDelete(int data)
        {
            //find node then set property isdeleted to true
            TreeNode toDelete = Find(data);
            if (toDelete != null)
            {
                toDelete.Delete();
            }
        }

        //find smallest value in the tree
        public Nullable<int> Smallest()
        {
            //if we have a root node then we can search for the smallest node
            if (root != null)
            {
                return root.SmallestValue();
            }
            else
            {//otherwise we return null
                return null;
            }
        }

        //find largest value in the tree
        public Nullable<int> Largest()
        {
            //if we have a root node then we can search for the largest node
            if (root != null)
            {
                return root.LargestValue();
            }
            else
            {//otherwise we return null
                return null;
            }
        }


        //Tree Traversal 
        //In order - goes left to right basically find the left leaf node then its parent then see if the right node has a left node then recursivly go up the tree
        // basically keep going left then recursive to parent then right
        //numbers will be in ascending order
        public void InOrderTraversal()
        {
            if (root != null)
                root.InOrderTraversal();
        }


        //Preorder
        //Go to the Root then the left then the right recursively
        public void PreorderTraversal()
        {
            if (root != null)
                root.PreOrderTraversal();
        }

        //Postorder
        //Go to the Left then the right then the root recursively
        public void PostorderTraversal()
        {
            if (root != null)
                root.PostorderTraversal();
        }


        public int NumberOfLeafNodes()
        {
            //if root is null then  number of leafs is zero
            if (root == null)
            { return 0; }

            return root.NumberOfLeafNodes();
        }

        public int Height()
        {
            //if root is null then height is zero
            if (root == null)
            { return 0; }

            return root.Height();
        }


        //Check if the binary tree is balanced. A balanced tree occurs when the height of two subtrees of any node do not differe more than 1.
        public bool IsBalanced()
        {
            if (root == null)//Empty Tree
            {
                return true;
            }

            return root.IsBalanced();
        }


        //There are many self balancing trees
        //Some to look at are
        //Red Black Trees
        //AVL Trees




    }
}
