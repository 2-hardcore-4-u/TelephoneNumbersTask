using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string[] telephone = new string[N];
        for (int i = 0; i < N; i++)
        {
            telephone[i] = Console.ReadLine();
        }

        Trie trie = new Trie(telephone);

        Console.WriteLine(trie.Size);
    }
}

public class Trie
{
    public struct Letter
    {
        public const string Chars = "1234567890";
        public static implicit operator Letter(char c)
        {
            return new Letter() { Index = Chars.IndexOf(c) };
        }
        public int Index;
        public char ToChar()
        {
            return Chars[Index];
        }
        public override string ToString()
        {
            return Chars[Index].ToString();
        }
    }

    public int Size = 0;

    public class Node
    {
        public string Word;
        public bool IsTerminal { get { return Word != null; } }
        public Dictionary<Letter, Node> Edges = new Dictionary<Letter, Node>();
    }

    public Node Root = new Node();

    public Trie(string[] words)
    {
        for (int w = 0; w < words.Length; w++)
        {
            var word = words[w];
            var node = Root;
            for (int len = 1; len <= word.Length; len++)
            {
                var letter = word[len - 1];
                Node next;
                if (!node.Edges.TryGetValue(letter, out next))
                {
                    next = new Node();
                    if (len == word.Length)
                    {
                        next.Word = word;
                    }
                    node.Edges.Add(letter, next);
                    this.Size++;
                }
                node = next;
            }
        }
    }
}