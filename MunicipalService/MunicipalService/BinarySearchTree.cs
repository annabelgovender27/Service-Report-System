using System;

namespace MunicipalService
{
    public class BinarySearchTree<T> where T : class
    {
        // Private nested class representing a single node in the binary search tree
        private class TreeNode
        {
            // The key used for ordering and searching
            public int Key;
            // The actual data stored in the node
            public T Value;
            // Reference to left child (smaller keys)
            public TreeNode Left;
            // Reference to right child (larger keys)
            public TreeNode Right;   

            // Constructor to initialize a new tree node
            public TreeNode(int key, T value)
            {
                Key = key;
                Value = value;
                
            }
        }

        private TreeNode root;

        // method to insert a new key-value pair into the tree
        public void Insert(int key, T value)
        {
            
            root = InsertRec(root, key, value);
        }

        //  helper method for insertion
        // returns the node that should be at this position in the tree
        private TreeNode InsertRec(TreeNode node, int key, T value)
        {
            // Base case: if we've reached a null position, create a new node here
            if (node == null)
                return new TreeNode(key, value);

            // Recursive cases:
            // If the new key is smaller than current node's key, go left
            if (key < node.Key)
                node.Left = InsertRec(node.Left, key, value);
            // If the new key is larger than current node's key, go right
            else if (key > node.Key)
                node.Right = InsertRec(node.Right, key, value);
           

            return node;  
        }

        // Public method to search for a value by key
        // Returns null if key is not found
        public T Search(int key)
        {
           
            return SearchRec(root, key);
        }

        // Recursive helper method for searching
        private T SearchRec(TreeNode node, int key)
        {
            // Base case: key not found in this branch
            if (node == null) return null;

            // Check if we found the target key
            if (key == node.Key)
                return node.Value;          
            else if (key < node.Key)
                return SearchRec(node.Left, key);  
            else
                return SearchRec(node.Right, key); 
        }
    }
}