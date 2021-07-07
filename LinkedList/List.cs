using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{

    public class Node<T> where T : IComparable 
    {
       public Node<T> Next;
                     
       public T data;

       public Node(T data)
        {
            this.data = data;
        }  
    
    }



    public  class List<T>:IEnumerable<T> where T:IComparable
    {
        private Node<T> _head;
        private Node<T> _tail;
        public int Count { get; private set; }
        public bool isEmpty { get { return Count == 0; } }


        
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if(_head == null)
            {
                _head = _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
                ++Count;
            }
        }

        public bool Delete(T data)
        {
            Node<T> current = _head;
            Node<T> previous = null;

            while (current!= null)
            {
                if (current.data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            _tail = previous;
                    }

                    
                    else
                    {
                        _head = _head.Next;

                        if (_head == null)
                            _tail = _head;
                    }

                    --Count;
                    return true;
                }

                previous = current;
                current = current.Next;
                


            }
            return false;
        }

        public bool Contains(T data)
        {
            Node<T> node = _head;
            while (node!=null)
            {
                if (node.data.Equals(data))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.data;
                current = current.Next;
            }
        }
    }
}
