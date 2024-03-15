using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment3
{
    public class OurLinkedList:ILinkedListADT
    {
        //properties
        public Node<T>? Head { get; set; }
        public Node<T>? Tail { get; set; }
        //methods
        public bool IsEmpty()
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
        public void AddFirst(User value)
        {
            Node<T> newNode = new Node<T>(value);
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
            Count++;
        }
    }
}
