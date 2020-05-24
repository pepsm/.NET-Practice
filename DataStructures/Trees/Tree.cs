﻿using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; private set; }
    public List<Tree<T>> Children { get; private set; }
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public void Print(int indent = 0)
    {
        this.Print(this, indent);
    }

    private void Print(Tree<T> node, int indent)
    {
        Console.WriteLine(new string(' ', indent * 2 ) + node.Value);

        foreach (var child in node.Children)
        {
            Print(child, indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);
        foreach (var child in this.Children)
        {
            child.Each(action); 
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();

        // Recursion
        this.DFS(this, result);

        return result;
    }
    private void DFS(Tree<T> node, List<T> result)
    {
        foreach (var child in node.Children)
        {
            this.DFS(child, result);
        }

        result.Add(node.Value);
    }

    public IEnumerable<T> OrderBFS()
    {
        Queue<Tree<T>> queue = new Queue<Tree<T>>();
        List<T> result = new List<T>();

        queue.Enqueue(this);

        while(queue.Count > 0)
        {
            Tree<T> current = queue.Dequeue();
            result.Add(current.Value);

            foreach (Tree<T> child in current.Children)
            {
                queue.Enqueue(child);
            }
        }
        return result;
    }
}
