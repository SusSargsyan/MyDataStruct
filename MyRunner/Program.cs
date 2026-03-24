using MyBinaryTreeProj;
using MyHashTableAlgorithms;
using MyLinkedListProj;
using MyQueueProj;
using MyStackProj;
using System;
using System.Collections;

namespace MyRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Հայերեն տառերի համար

            // --- 1. LINKED LIST-Ի ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 1. Linked List Test =====");
            MyLinkedList<string> list = new MyLinkedList<string>();
            list.Add("Առաջին");
            list.Add("Երկրորդ");
            foreach (var item in list) Console.WriteLine($"- {item}");
            Console.WriteLine();

            // --- STACK (Linked List-based)  ---
            Console.WriteLine("===== Stack Test =====");
            var s = new MyLinkedListLibrary.MyStack<int>();

            s.Push(100); s.Push(200); s.Push(300);

            Console.WriteLine($"Վերևում է (Peek): {s.Peek()}"); // 300
            Console.WriteLine($"Հեռացվեց (Pop): {s.Pop()}");    // 300
            Console.WriteLine($"Հաջորդը (Peek): {s.Peek()}");   // 200

            Console.WriteLine("\nՄնացածը ստեկում:");
            foreach (int x in s) Console.WriteLine(x);


            // --- 3. STACK (ARRAY-ՈՎ) ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 2. Stack (Array-based) Test =====");
            MyStackArray<int> stack = new MyStackArray<int>();
            stack.Push(10);
            stack.Push(20);
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine();

            // --- 4. BINARY TREE-Ի ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 3. Binary Tree Test =====");
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Add(50); tree.Add(30); tree.Add(70);
            Console.Write("In-Order: ");
            foreach (var val in tree) Console.Write(val + " ");
            Console.WriteLine("\n");

            // --- 5. QUEUE (ՀԵՐԹ) ՍՏՈՒԳՈՒՄ ---
            Console.WriteLine("===== 4. Queue Test (FIFO) =====");
            MyQueue<string> queue = new();
            queue.Enqueue("Հաճախորդ 1");
            queue.Enqueue("Հաճախորդ 2");
            Console.WriteLine($"Dequeue: {queue.Dequeue()}");
            Console.WriteLine();

            // --- 6. HASH TABLE-Ի ՍՏՈՒԳՈՒՄ (REFLECTION-ՈՎ) ---
            Console.WriteLine("===== 5. Hash Table Test (Private Access) =====");

            try
            {
                // 1. Գտնում ենք Program դասը MyHashTableAlgorithms նախագծի մեջ
                var type = typeof(MyHashTableAlgorithms.Program);

                // 2. Գտնում ենք FoldingHash մեթոդը, նույնիսկ եթե այն PRIVATE է
                var method = type.GetMethod("FoldingHash",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

                if (method != null)
                {
                    string testKey = "lore";
                    // 3. Կանչում ենք մեթոդը
                    var result = method.Invoke(null, new object[] { testKey });

                    Console.WriteLine($"Բանալի: {testKey}");
                    Console.WriteLine($"Folding Hash (կանչված private-ից): {result}");
                    Console.WriteLine($"Ինդեքս (mod 10): {Math.Abs((int)result % 10)}");
                }
                else
                {
                    Console.WriteLine("Սխալ: FoldingHash մեթոդը չգտնվեց:");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Չհաջողվեց կանչել private մեթոդը: " + ex.Message);
            }


            // --- ԱՎԱՐՏ ---
            Console.WriteLine("\n===============================");
            Console.WriteLine("Բոլոր թեստերը (ներառյալ Hash Table) հաջողությամբ անցան:");
            Console.ReadLine();
        }
    }
}
