using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsHW3
{
    /// <summary>
    /// Singly linked node class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public T Data;
        public Node<T> Next;

        public Node(T Data, Node<T> Next)
        {
            this.Data = Data;
            this.Next = Next;
        }
    }
}
