using System;

namespace BinaryTreeExample
{
    public class TreeNode
    {   //property to store the nodes data could be a key and object pair
        private int data;
        public int Data
        {
            get { return data; }
        }

        private TreeNode rightNode;
        public TreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }//Right Child

        private TreeNode leftNode;
        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }//left Child

        private bool isDeleted;//soft delete variable
        public bool IsDeleted
        {
            get { return isDeleted; }
        }

        //Node constructor
        public TreeNode(int value)
        {
            data = value;
        }

        //Method to set soft delete
        public void Delete()
        {
            isDeleted = true;
        }

        public TreeNode Find(int value)
        {
            //this node is the starting current node
            TreeNode currentNode = this;

            //loop through this node and all of the children of this node
            while (currentNode != null)
            {
                //if the current nodes data is equal to the value passed in return it
                if (value == currentNode.data && isDeleted == false)//soft delete check
                {
                    return currentNode;
                }
                else if (value > currentNode.data)//if the value passed in is greater than the current data then go to the right child
                {
                    currentNode = currentNode.rightNode;
                }
                else//otherwise if the value is less than the current nodes data the go to the left child node 
                {
                    currentNode = currentNode.leftNode;
                }
            }
            //Node not found
            return null;
        }

        public TreeNode FindRecursive(int value)
        {
            //value passed in matches nodes data return the node
            if (value == data && isDeleted == false)
            {
                return this;
            }
            else if (value < data && leftNode != null)//if the value passed in is less than the current data then go to the left child
            {
                return leftNode.FindRecursive(value);
            }
            else if (rightNode != null)//if its great then go to the right child node
            {
                return rightNode.FindRecursive(value);
            }
            else
            {
                return null;
            }
        }


        //recursively calls insert down the tree until it find an open spot
        public void Insert(int value)
        {
            //if the value passed in is greater or equal to the data then insert to right node
            if (value >= data)
            {   //if right child node is null create one
                if (rightNode == null)
                {
                    rightNode = new TreeNode(value);
                }
                else
                {//if right node is not null recursivly call insert on the right node
                    rightNode.Insert(value);
                }
            }
            else
            {//if the value passed in is less than the data then insert to left node
                if (leftNode == null)
                {//if the leftnode is null then create a new node
                    leftNode = new TreeNode(value);
                }
                else
                {//if the left node is not null then recursively call insert on the left node
                    leftNode.Insert(value);
                }
            }
        }

        public Nullable<int> SmallestValue()
        {
            // once we reach the last left node we return its data
            if (leftNode == null)
            {
                return data;
            }
            else
            {//otherwise keep calling the next left node
                return leftNode.SmallestValue();
            }
        }

        internal Nullable<int> LargestValue()
        {   // once we reach the last right node we return its data
            if (rightNode == null)
            {
                return data;
            }
            else
            {//otherwise keep calling the next right node
                return rightNode.LargestValue();
            }
        }

        //Number return in ascending order
        //Left->Root->Right Nodes recursively of each subtree 
        public void InOrderTraversal()
        {
            //first go to left child its children will be null so we print its data
            if (leftNode != null)
                leftNode.InOrderTraversal();
            //Then we print the root node 
            Console.Write(data + " ");

            //Then we go to the right node which will print itself as both its children are null
            if (rightNode != null)
                rightNode.InOrderTraversal();
        }


        //Root->Left->Right Nodes recursively of each subtree 
        public void PreOrderTraversal()
        {
            //First we print the root node 
            Console.Write(data + " ");

            //Then go to left child its children will be null so we print its data
            if (leftNode != null)
                leftNode.PreOrderTraversal();

            //Then we go to the right node which will print itself as both its children are null
            if (rightNode != null)
                rightNode.PreOrderTraversal();
        }

        //Left->Right->Root Nodes recursively of each subtree 
        public void PostorderTraversal()
        { 
            //First go to left child its children will be null so we print its data
            if (leftNode != null)
                leftNode.PostorderTraversal();

            //Then we go to the right node which will print itself as both its children are null
            if (rightNode != null)
                rightNode.PostorderTraversal();

            //Then we print the root node 
            Console.Write(data + " ");
        }


        public int Height()
        {
            //return 1 when leaf node is found
            if (this.leftNode == null && this.rightNode == null)
            {
                return 1; //found a leaf node
            }

            int left = 0;
            int right = 0;

            //recursively go through each branch
            if (this.leftNode != null)
                left = this.leftNode.Height();
            if (this.rightNode != null)
                right = this.rightNode.Height();

            //return the greater height of the branch
            if (left > right)
            {
                return (left + 1);
            }
            else
            {
                return (right + 1);
            }

        }

        public int NumberOfLeafNodes()
        {
            //return 1 when leaf node is found
            if (this.leftNode == null && this.rightNode == null)
            {
                return 1; //found a leaf node
            }

            int leftLeaves = 0;
            int rightLeaves = 0;

            //recursively call NumOfLeafNodes returning 1 for each leaf found
            if (this.leftNode != null)
            {
                leftLeaves = leftNode.NumberOfLeafNodes();
            }
            if (this.rightNode != null)
            {
                rightLeaves = rightNode.NumberOfLeafNodes();
            }

            //add values together 
            return leftLeaves + rightLeaves;
        }

        public bool IsBalanced()
        {
            int LeftHeight = LeftNode != null ? LeftNode.Height() : 0;
            int RightHeight = RightNode != null ? RightNode.Height() : 0;

            int heightDifference = LeftHeight - RightHeight;

            if (Math.Abs(heightDifference) > 1)
            {
                return false;
            }
            else
            {
                return ((LeftNode != null ? LeftNode.IsBalanced() : true) && (RightNode != null ? RightNode.IsBalanced() : true));
            }
        }
    }
}