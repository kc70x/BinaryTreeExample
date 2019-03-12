using System;
using System.Collections.Generic;

namespace BinaryTreeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree\n");

            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Insert(75);
            binaryTree.Insert(57);
            binaryTree.Insert(90);
            binaryTree.Insert(32);
            binaryTree.Insert(7);
            binaryTree.Insert(44);
            binaryTree.Insert(60);
            binaryTree.Insert(86);
            binaryTree.Insert(93);
            binaryTree.Insert(99);
            binaryTree.Insert(100);


            //Console.WriteLine("In Order Traversal (Left->Root->Right)");
            //binaryTree.InOrderTraversal();
            //Console.WriteLine("\nPre Order Traversal (Root->Left->Right)");
            //binaryTree.PreorderTraversal();
            //Console.WriteLine("\nPost Order Traversal (Left->Right->Root)");
            //binaryTree.PostorderTraversal();

            //Console.WriteLine("\nFind 99");
            //var node = binaryTree.Find(99);
            //Console.WriteLine(node.Data);
            //Console.WriteLine("Find Recursively 99");
            //var nodeR = binaryTree.FindRecursive(99);
            //Console.WriteLine(nodeR.Data);
            //Console.WriteLine("Delete a Leaf Node (44)");
            //binaryTree.Remove(44);
            //Console.WriteLine("Delete a Node with one child (93)");
            //binaryTree.Remove(93);
            //Console.WriteLine("Delete a Node with two child nodes (75)");
            //binaryTree.Remove(75);
            //Console.WriteLine("SoftDelete a Node with one child (93)");
            //binaryTree.SoftDelete(93);


            //Console.WriteLine("Get Smallest node");
            //Console.WriteLine(binaryTree.Smallest());
            //Console.WriteLine("Get Largest node");
            //Console.WriteLine(binaryTree.Largest());
            //Console.WriteLine("Get the number of leaf nodes");
            //Console.WriteLine(binaryTree.NumberOfLeafNodes());
            //Console.WriteLine("Get the height of the tree");
            //Console.WriteLine(binaryTree.Height());

            //Check if the binary tree is balanced. A balanced tree occurs when the height of two subtrees of any node do not differe more than 1.
            //bool balanced = binaryTree.IsBalanced();

        }


        public static int getHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return Math.Max(getHeight(root.LeftNode), getHeight(root.RightNode)) + 1;
        }

        public static bool isBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            int heightDiff = getHeight(root.LeftNode) - getHeight(root.RightNode);
            if (Math.Abs(heightDiff) > 1)
            {
                return false;
            }
            else
            {
                return (isBalanced(root.LeftNode) && isBalanced(root.RightNode));
            }
        }


    }
}
