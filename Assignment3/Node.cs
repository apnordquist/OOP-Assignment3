using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment3
{
    public class Node<T>
    {
            // Public property 'Data' holds the value of the node.
            public T Data { get; set; }
            // Public property 'Next' points to the next node in the list, initially null.
            public Node<T>? Next { get; set; }
            // Constructor to initialize a new node with provided data; 'Next' is by default null.
            public Node(T data)
            {
                this.Data = data; // Set the data part of the node.
            }
    }
}
