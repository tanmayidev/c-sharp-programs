using System;
using System.Collections.Generic;
using System.Text;

namespace Trees {
    public class TreeNode {
        public int Data;
        public TreeNode left;
        public TreeNode right;
        public void DisplayNode() {
            Console.Write(Data + " ");
        }
    }
    public class  BinarySearchTree {
        public TreeNode root;
        public BinarySearchTree() {
            root = null;
        }

        public void Insert(int i) {
            TreeNode newNode = new TreeNode();
            newNode.Data = i;
            if(root == null) {
                root = newNode;
            }
            else {
                TreeNode current = root;
                TreeNode parent;
                while (true) {
                    parent = current;
                    if (i < current.Data) {
                        current = current.left;
                        if(current == null) {
                            parent.left = newNode;
                            break;
                        }
                    }
                    else {
                        current = current.right;
                        if(current == null) {
                            parent.right = newNode;
                            break;
                        }
                    }
                }

            }
        }

        /*
         *                 23
         *           16           45
         *     3          22    37    99
         */
        //

        // 3 22 16 37 99 45 23
        public void PostOrder(TreeNode theRoot) {
            if (!(theRoot == null)) {
                PostOrder(theRoot.left);
                PostOrder(theRoot.right);
                theRoot.DisplayNode();
            }
        }

        // 3 16 22 23 37 45 99
        public void InOrder(TreeNode theRoot) {
            if (!(theRoot == null)) {
                InOrder(theRoot.left);
                theRoot.DisplayNode();
                InOrder(theRoot.right);
            }
        }

        // Preorder        
        // 23 16 3 22 45 37 99
        public void PreOrder(TreeNode theRoot) {
            if (!(theRoot == null)) {
                theRoot.DisplayNode();
                PreOrder(theRoot.left);
                PreOrder(theRoot.right);
            }
        }

        public int FindMin() {
            TreeNode current = root;
            while (!(current.left == null)) {
                current = current.left;
            }
            return current.Data;
        }

        public int FindMax() {
            TreeNode current = root;
            while (!(current.right == null)) {
                current = current.right;
            }
            return current.Data;
        }

        public TreeNode Find(int key) {
            TreeNode current = root;
            while (current.Data != key) {
                if(key < current.Data) {
                    current = current.left;
                }
                else {
                    current = current.right;
                }
                if(current == null) {
                    return null;
                }
            }
            return current;
        }


        public TreeNode Delete(int key) {
            TreeNode current = root;
            TreeNode parent = root;
            bool isLeftChild = true;
            while (current.Data != key) {
                parent = current;
                if(key < current.Data) {
                    isLeftChild = true;
                    current = current.left;
                } else {
                    isLeftChild = false;
                    current = current.right;
                }
                if(current == null) {
                    return null;
                }
            }

            // Leaf node to be deleted is 3
            /*
             *                 23
             *           16           45
             *     3          22    37    99
             *    
             */
            if ((current.left == null) && (current.right == null)) {
                if(current == root) {
                    root = null;
                } else if (isLeftChild) {
                    parent.left = null;
                } else {
                    parent.right = null;
                }
            }
            
            else if (current.right == null) {
                // Right tree is empty node to be deleted is 23
                /*
                 *                 23
                 *           16          
                 *     3          22    
                 *    
                 */
                if (current == root) {
                    root = current.left;
                }
                /* 3 to be deleted
                 *                 23
                 *           16           45
                 *      3              37    
                 *  2  
                 */
                 else if (isLeftChild) {
                    parent.left = current.left;
                 }
                 /* 99 to be deleted
                 *                 23
                 *           16          45
                 *     3          22        99
                 *                       66
                 */
                 else {
                    parent.right = current.right;
                }
            }
            else if (current.left == null) {
                /* 23 is the node to be deleted
                *                 23
                *                      45
                *                  37    99
                *    
                */
                if(current == root) {
                    root = current.right;
                }
                /* 16 is the node to be deleted
                *
                *                 23
                *           16           45
                *               22    37    99
                *                   
                */
                else if (isLeftChild) {
                    parent.left = current.right;
                }
                // 45 is to be deleted
                /*
                 *                 23
                 *           16          45
                 *        3      22         99 
                 *    
                 */
                else {
                    parent.right = current.right;
                }
            }

             /*
              * 
              *                                      70
              *                              52 (node to be deleted)
              *                        49              54
              *                    46      40        53      55
              *                                      
              * 
              *                        45
              *                                53 
              *                        49            54
              *                    46      40              55
              * */
             /*
              *   *                 23
             *           16           45
             *     3          22    37    99
              * */
             else {
                TreeNode successor = GetSuccessor(current);
                if (current == root)
                    root = successor;
                else if (isLeftChild)
                    parent.left = successor;
                else
                    parent.right = successor;
                successor.left = current.left;
               
            }

            /*
             * 
             *                      45
             *                              52 (node to be deleted)
             *                        49              54
             *                    46      40        53      55
             *                                      
             * 
             *                        45
             *                                53 
             *                        49            54
             *                    46      40              55
             * */

            TreeNode GetSuccessor(TreeNode delNode) {
                TreeNode successorParent = delNode;
                TreeNode successor = delNode;
                TreeNode current = delNode.right;
                while (!(current == null)) {
                    successorParent = current;
                    successor = current;
                    current = current.left;
                }
                if (!(successor == delNode.right)) {
                    successorParent.left = successor.right;
                    successor.right = delNode.right;
                }
                return successor;
            }
            
            return current;
        }



        public static void Main() {
            BinarySearchTree nums = new BinarySearchTree();
            nums.Insert(23);
            nums.Insert(45);
            nums.Insert(16);
            nums.Insert(37);
            nums.Insert(3);
            nums.Insert(99);
            nums.Insert(22);
            Console.WriteLine("Inorder traversal: ");
            nums.InOrder(nums.root);
            Console.WriteLine("Minimum value is " + nums.FindMin());
            Console.WriteLine("Maximum value is " + nums.FindMax());
            bool found = nums.Find(43) != null;
            Console.WriteLine("43 node is present: " + found);
            Console.WriteLine("45 node is present: " + (nums.Find(45) != null));
            Console.WriteLine("3 node is present: " + (nums.Find(3) != null));
            Console.WriteLine("23 node is present: " + (nums.Find(23) != null));
            Console.WriteLine("29 node is present: " + (nums.Find(29) != null));
            Console.WriteLine("99 node is present: " + (nums.Find(99) != null));
            nums.Delete(45);
        }
    }
}
