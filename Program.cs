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
            int[] dataRand = RandArray(78);
            
            // create nodes for each element and add to tree
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine("Node " + i + " created");
                TreeInsertion(data[i]);
            }

            Console.WriteLine("TREE CREATED");
            Console.WriteLine("Min value of tree is " + SearchMin().value);
            Console.WriteLine("Max value of tree is " + SearchMax().value);
            Node search = Search(33);
            Console.WriteLine("Node: " + search + " Node value: " + search.value + "    Child Left: " + search.leftChild + "    Child Right: " + search.rightChild);
        }

        public static int[] RandArray(int max)
        {
            int[] randArray = new int[max];
            
            for (int i = 0; i < max; i++)
            {
                Random r = new Random();
                int num = r.Next(1, 10000);

                randArray[i] = num;
            }
            
            return randArray;
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
                    if (value <= parentNode.value) //added <= to so that duplicates go to the left of the tree
                    {
                        curNode = curNode.leftChild;

                        // insert LEFT
                        if (curNode == null)
                        {
                            parentNode.leftChild = tempNode;
                            Console.WriteLine("Added node LEFT  (depth: " + depth + "   val: " + value + "  childLeft:  " + parentNode.leftChild + " childRight: " + parentNode.rightChild + ")");
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
                            Console.WriteLine("Added node RIGHT (depth: " + depth + "   val: " + value + "  childLeft:  " + parentNode.leftChild + " childRight:    " + parentNode.rightChild + ")");
                            return;
                        }
                    }

                    depth++;
                }
                
            }
        }
        
        static Node Search(int value) // Search through Tree
        {
            Node curNode = new Node();

            curNode = root;

            while(true)
            {
                //if searching value is smaller -> go left
                if (value < curNode.value)
                {
                    curNode = curNode.leftChild;
                }
                else if (value > curNode.value)
                {
                    curNode = curNode.rightChild;
                }

                // if fails
                if (curNode == null)
                {
                    Console.WriteLine("Node not found");
                    return null;
                }

                //if val = node value
                if (value == curNode.value)
                {
                    Console.WriteLine("Node Found");
                    return curNode;
                }
            }
        }

        public static Node SearchMin()
        {
            Node parent = new Node();
            Node min = new Node();

            // start from root
            parent = root;

            while(true)
            {
                // loop through until left child of Node is empty
                if (parent.leftChild == null)
                {
                    min = parent;
                    return min;
                }
                else
                {
                    parent = parent.leftChild;
                }
            }
        }

        public static Node SearchMax()
        {
            Node parent = new Node();
            Node min = new Node();

            // start from root
            parent = root;

            while(true)
            {
                // loop through until left child of Node is empty
                if (parent.rightChild == null)
                {
                    min = parent;
                    return min;
                }
                else
                {
                    parent = parent.rightChild;
                }
            }
        }
    }
}
