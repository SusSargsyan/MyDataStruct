using BinaryTreeProj; 
using MyBinaryTreeProj;
using MyLinkedListProj;
using System;

namespace MyRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Ծրագիրը սկսվեց ===");

            // Ստուգում ենք Binary Tree-ն
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Add(50);
            tree.Add(20);
            tree.Add(80);

            Console.Write("Tree Elements: ");
            foreach (var item in tree) Console.Write(item + " ");

            Console.WriteLine("\n\nԱմեն ինչ ճիշտ է աշխատում:");
            Console.ReadLine();
        }
    }
}