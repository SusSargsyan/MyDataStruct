using System;
using MyLinkedListProj;
using MyStackProj;
using MyBinaryTreeProj;
using MyQueueProj; 

namespace MyRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- 1. LINKED LIST-Ի ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 1. Linked List Test =====");
            MyLinkedList<string> list = new MyLinkedList<string>();
            list.Add("Առաջին");
            list.Add("Երկրորդ");
            foreach (var item in list) Console.WriteLine($"- {item}");
            Console.WriteLine();

            // --- 2. STACK (ARRAY-ՈՎ) ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 2. Stack (Array-based) Test =====");
            MyStackArray<int> stack = new MyStackArray<int>();
            stack.Push(10);
            stack.Push(20);
            Console.WriteLine($"Pop: {stack.Pop()}"); // Կհանի 20-ը (LIFO)
            Console.WriteLine();

            // --- 3. BINARY TREE-Ի ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 3. Binary Tree Test =====");
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Add(50); tree.Add(30); tree.Add(70);
            Console.Write("In-Order: ");
            foreach (var val in tree) Console.Write(val + " ");
            Console.WriteLine("\n");

            // --- 4. QUEUE (ՀԵՐԹ) ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 4. Queue Test (FIFO) =====");
            MyQueue<string> queue = new MyQueue<string>();

            // Ավելացնում ենք հերթի մեջ
            queue.Enqueue("Հաճախորդ 1");
            queue.Enqueue("Հաճախորդ 2");
            queue.Enqueue("Հաճախորդ 3");

            Console.WriteLine($"Peek (Ո՞վ է առաջինը): {queue.Peek()}"); // Պետք է լինի Հաճախորդ 1

            // Հանում ենք հերթից
            Console.WriteLine($"Dequeue (Սպասարկվեց): {queue.Dequeue()}"); // Դուրս է գալիս Հաճախորդ 1-ը
            Console.WriteLine($"Հաջորդը սպասարկման համար: {queue.Peek()}"); // Հիմա Հաճախորդ 2-ն է

            Console.WriteLine("\nՄնացածը հերթում:");
            foreach (var item in queue)
            {
                Console.WriteLine($"- {item}");
            }

            // --- ԱՎԱՐՏ ---
            Console.WriteLine("\n===============================");
            Console.WriteLine("Բոլոր թեստերը հաջողությամբ անցան:");
            Console.ReadLine();
        }
    }
}
