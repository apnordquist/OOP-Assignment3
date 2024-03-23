using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public int Count() //adam
        {
            return Counter;
        }

        public void RemoveFirst()//vedant
        {
            if (Head == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Head = Head.Next;
            Counter--;

            if (Head == null)
            {
                Tail = null;
            }
        }

        public void RemoveLast()// vedant
        {
            if (Head == null)
            {
                Console.WriteLine("The list is empty/Null");
                return;
            }

            if (Head == Tail)
            {
                Head = null;
                Tail = null;
                Counter = 0;
                return;
            }

            Node<User>? current = Head;
            while (current!.Next != Tail)
            {
                current = current.Next;
            }

            current.Next = null;
            Tail = current;
            Counter--;
        }

        public void Remove(int index)//vedant
        {
            if (index < 0 || index >= Counter)
            {
                Console.WriteLine("The index is out of range of the list.");
                return;
            }

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            if (index == Counter - 1)
            {
                RemoveLast();
                return;
            }

            Node<User>? current = Head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current!.Next;
            }

            current.Next = current.Next!.Next;
            Counter--;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= Counter)
            {
                throw new IndexOutOfRangeException("Index is out of range of the list.");
            }

            Node<User>? current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            return current!.Data;
        }

        public int IndexOf(User value)//vedant 
        {
            Node<User>? current = Head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }

            return -1; 
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

    
        public void ReverseOrder(UserLinkedList<User> list) //additional method from assignement
        {
            int revCounter = list.Count(); //get list length
            UserLinkedList<User> revList = new UserLinkedList<User>();
            while (revCounter >= 0)
            {
                Node<User> current = Head;
                for (int i = 0; i < revCounter - 1; i++) //adjust index to work with counter
                {
                    current = current.Next; //go to last item
                }
                revList.AddFirst(current.Data); //add to new list
                revCounter--;
            }
            list = revList; //replace list with the reversed list
        }

        public void JoinLists(UserLinkedList<User> list1, UserLinkedList<User> list2) //additional method from assignement
        {
            int index = list2.Counter; //get length of the second list
            while (index > 0) //loop through the second list
            {
                list1.AddLast(list2.Head.Data); //add to the first value to the end of the first list
                list2.RemoveFirst(); //remove from the second list
            }
        }
    }
}
