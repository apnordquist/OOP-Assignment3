using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Assignment3
{
    public class UserLinkedList<User> : ILinkedListADT
    {
        //properties
        public Node<User>? Head { get; set; }
        public Node<User>? Tail { get; set; }
        public int Counter { get; set; }
        //methods
        public bool IsEmpty() //adam
        {
            if (Head == null) // check if head is empty
            {
                return true;
            }
            else // if head is present, can't be empty
            {
                return false;
            }
        }
        public void Clear() //adam
        {
            //reset all properties
            Head = null;
            Tail = null;
            Counter = 0;
        }
        public void AddFirst(User value) //adam
        {
            Node<User> newNode = new Node<User>(value);
            if(Head == null) //replace head and tail if list is empty
            {
                Head = newNode;
                Tail = newNode;
            }
            else //add exisitng head as next then add node as new head
            {
                newNode.Next = Head;
                Head = newNode;
            }
            Counter++;
        }
        public void AddLast(User value) //adam
        {
            Node<User> newNode = new Node<User>(value);
            if (Head == null) //replace head and tail if list is empty
            {
                Head = newNode;
            }
            else //add new node as the tail's next property
            {
                Tail.Next = newNode;
            }
            Tail = newNode; //create new tail
            Counter++;
        }
        public void Add(User value, int index) //adam
        {
            Node<User> newNode = new Node<User>(value);
            if (index < 0 || index > Counter) //check if position is in list
            {
                Console.WriteLine("The index is out of range of the list.");
            }
            else
            {
                    Node<User> current = Head;
                    for (int i = 0; i < index - 1; i++) //adjust index to work with counter
                    {
                        current = current.Next;
                    }
                    newNode.Next = current; //move current to next
                    current = newNode; //make the current the new node
                Counter++;
            }
        }
        public void Replace(User value, int index) //adam
        {
            Node<User> newNode = new Node<User>(value);
            if (index < 0 || index > Counter) //check if position is in list
            {
                Console.WriteLine("The index is out of range of the list.");
            }
            else
            {
                Node<User> current = Head;
                for (int i = 0; i < index - 1; i++) //adjust index to work with counter
                {
                    current = current.Next;
                }
                current = newNode; //replace the position
            }
        }
        public int Count()
        {
            return Counter;
        }

        public void RemoveFirst()
        { }

        public void RemoveLast()
        { }

        public void Remove(int index)
        { }

        public User GetValue(int index)
        { }

        public int IndexOf(User value)
        { }

        public bool Contains(User value)
        { }
    }
}
