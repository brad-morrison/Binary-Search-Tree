using System;

namespace BST
{
    class Program
    {
        public class Node 
        {
            public int value;
            public Node leftChild;
            public Node rightChild;
        }

        public static Node root = null;

        static void Main(string[] args)
        {
            // input data to be sorted into tree
            int[] data = new int[] {51, 34, 13, 99, 9, 15, 33, 20, 56, 78, 42, 96, 122, 533, 566, 623, 784, 998};
            
            // create nodes for each element and add to tree
            for (int i = 0; i < data.Length; i++)
            {
                TreeInsertion(data[i]);
            }
        }

        
        public static void TreeInsertion(int value) // Create Tree/Insert Node
        {
            Node tempNode = new Node();
            Node curNode = new Node();
            Node parentNode = new Node();

            tempNode.value = value;
            tempNode.leftChild = null;
            tempNode.rightChild = null;

            // If no root exists, set this as root
            if (root == null)
            {
                Console.WriteLine("Created ROOT (" + value + ")");
                root = tempNode;
            }
            else
            {
                curNode = root;
                parentNode = null;

                // depth counter for visualization
                int depth = 0;

                while(true)
                {
                    parentNode = curNode;

                    // traverse LEFT
                    if (value < parentNode.value)
                    {
                        curNode = curNode.leftChild;

                        // insert LEFT
                        if (curNode == null)
                        {
                            parentNode.leftChild = tempNode;
                            Console.WriteLine("Added node LEFT (depth: " + depth + " val: " + value + " childLeft: " + parentNode.leftChild + " childRight: " + parentNode.rightChild + ")");
                            return;
                        }
                    }

                    // traverse RIGHT
                    if (value > parentNode.value)
                    {
                        curNode = curNode.rightChild;

                        // insert RIGHT
                        if (curNode == null)
                        {
                            parentNode.rightChild = tempNode;
                            Console.WriteLine("Added node RIGHT (depth: " + depth + " val: " + value + " childLeft: " + parentNode.leftChild + " childRight: " + parentNode.rightChild + ")");
                            return;
                        }
                    }

                    depth++;
                }
            }
        }
        
        static Node Search(int key, int[] data) // Search through Tree
        {
            var root = 25;
            return null;
        }
    }
}
