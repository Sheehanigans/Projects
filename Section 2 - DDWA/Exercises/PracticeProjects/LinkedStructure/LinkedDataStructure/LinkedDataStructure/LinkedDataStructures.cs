using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedDataStructure
{
    public class SinglyLinkedList<T> :  IEnumerable<T>
    {
        private Node<T> head;

        public void Add(T item)
        {
            //magic 
            var node = new Node<T>();
            node.Value = item;
            node.Link = head;
            head = node;
        }

        public T RemoveAt(int index)
        {
            if(index == 0)
            {
                if(head != null)
                {
                    T value = head.Value;
                    head = head.Link;
                    return value;
                }
            }
            else
            {
                var cursor = head;
                for(int i =0; i < index && cursor != null; i++)
                {
                    cursor = cursor.Link;
                }

                if(cursor != null)
                {
                    if (cursor.Link != null)
                    {
                        T value = cursor.Link.Value;
                        cursor.Link = cursor.Link.Link;
                        return value;
                    }
                }

            }

            return default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var cursor = head;
            while(cursor != null)
            {
                yield return cursor.Value;
                cursor = cursor.Link;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var cursor = head;
            while (cursor != null)
            {
                yield return cursor.Value;
                cursor = cursor.Link;
            }
        }

        class Node<T> //node  is a wrapper around a thing, can be self referencial 
        {
            public T Value { get; set; }
            public Node<T> Link { get; set; }
        }
    }
}
