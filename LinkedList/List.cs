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
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            this.data = data;
        }  
    
    }



    public  class List<T>:IEnumerable<T> where T:IComparable
    {
        private Node<T> _head = null;
        private Node<T> _tail = null;
        private int _count = 0;
       
        public bool isEmpty { get { return _count == 0; } }

        public T this[int index]
        {
            get
            {
                var current = _head;
                int count = 0;
                if (_head == null)
                    throw new NullReferenceException();

                if(index>_count)
                    throw new ArgumentOutOfRangeException();



                while (current != null && count != index)
                {
                   

                    current = current.Next;
                    count++;

                    


                }
               
                    return current.data;

            }
            set
            {
                var current = _head;
                int count = 0;
                if (_head == null)
                    throw new NullReferenceException();

                if (index > _count)
                    throw new ArgumentOutOfRangeException();



                while (current != null && count != index)
                {


                    current = current.Next;
                    count++;




                }

                current.data = value;

            }
        }

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
                ++_count;
            }
        }

        public void remove_at(int index)
        {
            Node<T> current = _head;
            Node<T> previous = null;
            int count = 0;

            while (current!= null && count != index)
            {
                if (count == index)
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

                    --_count;
                    return ;
                }

                previous = current;
                current = current.Next;
                


            }
            throw new ArgumentOutOfRangeException();
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

        public int Count()
        {
            return _count;
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
