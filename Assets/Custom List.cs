using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomList<T>
{
    private class Node
    {
        public T data;
        public Node next;

        public Node(T data)
        {
            this.data = data;
            next = null;
        }
    }

    private Node head;
    private int count;

    public CustomList()
    {
        head = null;
        count = 0;
    }

    public void Add(T item)
    {
        Node newNode = new Node(item);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = newNode;
        }
        count++;
    }

    public int Count
    {
        get { return count; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.data;
        }
    }
}
