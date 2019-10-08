using System;
using BinaryTree;
using System.Collections;
using System.Collections.Generic;

namespace TestBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(3);
            tree.Add(6);
            tree.Add(5);
            tree.Add(7);
            foreach (var item in tree)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
