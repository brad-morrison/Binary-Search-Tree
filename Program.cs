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
        public static bool treeExists = false;

        static void Main(string[] args)
        {
            loadMenu();

            
            //Console.WriteLine("Min value of tree is " + SearchMin().value);
            //Console.WriteLine("Max value of tree is " + SearchMax().value);
            //Node search = Search(33);
            //Console.WriteLine("Node: " + search + " Node value: " + search.value + "    Child Left: " + search.leftChild + "    Child Right: " + search.rightChild);
        }

        public static void loadMenu()
        {
            Console.Clear();
            string treeExists_string;
            if (treeExists) {   treeExists_string = "TREE EXISTS";  }  else {  treeExists_string = "EMPTY"; }

            Console.WriteLine("\n Tree [" + treeExists_string + "]");
            Console.WriteLine("\n\n Enter option: \n 1 - Create Tree \n 2 - Search Min Node \n 3 - Search Max Node \n 4 - Search Node");
            UserOption();
        }

        public static void UserOption()
        {
            string option;
            option = Console.ReadLine();
            int optionInt = Convert.ToInt32(option);

            switch(optionInt) 
            {
                case 1: Console.Clear();
                        Console.WriteLine("How big?: ");
                        string a;
                        a = Console.ReadLine();
                        CreateTree(Convert.ToInt32(a));
                        break;

                case 2: Console.Clear();
                        Console.WriteLine("The smallest value in the tree is " + SearchMin().value);
                        Console.WriteLine("\n\nPress any key to continue...");
                        Console.ReadKey();
                        loadMenu();
                        break;

                case 3: Console.Clear();
                        Console.WriteLine("The largest value in the tree is " + SearchMax().value);
                        Console.WriteLine("\n\nPress any key to continue...");
                        Console.ReadKey();
                        loadMenu();
                        break;

                case 4: Console.Clear();
                        Console.WriteLine("Enter value to search: ");
                        string b;
                        b = Console.ReadLine();
                        Node search = Search(Convert.ToInt32(b));
                        if (search == null)
                        {
                            Console.WriteLine("Node not found in tree");
                        }
                        else
                        {
                            Console.WriteLine("Node Found: [" + search + "] -- Value: [" + search.value + "] LeftChild: [" + search.leftChild + "] RightChild: [" + search.rightChild + "]");
                        }
                        Console.WriteLine("\n\nPress any key to continue...");
                        Console.ReadKey();
                        loadMenu();
                        break;

                default:    Console.Clear();
                            Console.WriteLine("Please enter an option between 1 and 5 \n\nPress and key to continue...");
                            Console.ReadKey();
                            loadMenu();
                            break;

            }
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

        public static void CreateTree(int size)
        {
            int[] dataRand = RandArray(size);

            // create nodes for each element and add to tree
            for (int i = 0; i < dataRand.Length; i++)
            {
                Console.WriteLine("Node " + i + " created");
                TreeInsertion(dataRand[i]);
            }

            Console.WriteLine("TREE CREATED");
            treeExists = true;
            loadMenu();
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
                    return null;
                }

                //if val = node value
                if (value == curNode.value)
                {
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
