using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    /// <summary>
    /// Generic hash table item
    /// </summary>
    /// <typeparam name="k">key of hash table item</typeparam>
    /// <typeparam name="V">Value of hash table item</typeparam>
    internal class HashNode<k, V>
    {
        public k key { get; set; }
        public V Value { get; set; }
        public HashNode<k,V> Next { get; set; }

        public HashNode(k key, V value)
        {
            this.key = key;
            this.Value = value;
        }
    }

    /// <summary>
    /// This is custom implementation of HashTable. It uses C# GetHashCode method to geneate hash code of each key passed.
    /// It illustrates hash table functionality using three main operations: Get, Remove and Add.
    /// Each hash table item is a HashNode class object which is root of the linked list which implenents separate chaining collision handing technique.
    /// </summary>
    /// <typeparam name="K">key type hash table<typeparam>
    /// <typeparam name="V">Value type of hash table</typeparam>
    public class HashMap<K, V>
    {
        //Arraylist of whicih custom hashtable is componsed of
        private ArrayList array;

        private int _size;

        public int Size
        {
            get { return _size; }
            private set { _size = value; }
        }

        private int capacity;

        public HashMap()
        {
            array = new ArrayList();
            capacity = 10;
            _size = 0;

            for(int i =0; i<capacity; i++)
            {
                array.Add(null);
            }
        }

        public bool IsEmpty()
        {
            return (Size == 0);
        }

        private  int GetBucketIndex(K key)
        {
            int hashCode = key.GetHashCode();
            hashCode = (hashCode < 0) ? hashCode * -1 : hashCode;
            return hashCode % capacity;
        }

        public V Remove(K key)
        {
            int index = GetBucketIndex(key);
            HashNode<K, V> rootNode = array[index] as HashNode<K, V>;
            
            HashNode<K, V> prevNode = null;

            V retVal = default(V);
            HashNode<K, V> temp = rootNode;
            while(temp != null)
            {
                if(temp.key.Equals(key))
                {
                    if (prevNode == null)
                    {
                        /// Case when root node is to be removed
                        array[index] = null;
                        retVal = temp.Value;
                    }
                    else
                    {
                        prevNode.Next = temp.Next;
                        retVal = temp.Value;
                    }
                }

                prevNode = temp;
                temp = temp.Next;
            }

            Size--;

            return retVal;
        }

        public V Get(K key)
        {
            int index = GetBucketIndex(key);
            HashNode<K, V> node = array[index] as HashNode<K, V>;

            V retVal = default(V);
            while(node != null)
            {
                if(node.key.Equals(key))
                {
                    retVal = node.Value;
                    break;
                }
                node = node.Next;
            }

            return retVal;
        }

        public void Add(K key, V value)
        {
            int index = GetBucketIndex(key);
            HashNode<K, V> node = array[index] as HashNode<K, V>;

            while(node != null)
            {
                if(node.key.Equals(key))
                {
                    // If key is already present then update existing value
                    node.Value = value;
                    return;
                }
                node = node.Next;
            }

            // In case if given key is not present then it needs to be added
            node = array[index] as HashNode<K, V>;

            HashNode<K, V> newNode = new HashNode<K, V>(key, value);
            newNode.Next = node;
            array[index] = newNode;
            Size++;

            // Check the load factor if it exceeds the limit (0.7) then double the capacity and again add each key, value pair
            double loadFactor = Size / capacity;

            if(loadFactor >= 0.7)
            {
                ArrayList temp = array;

                foreach(HashNode<K,V> tempNode in temp)
                {
                    HashNode<K, V> currentNode = tempNode;
                    while(currentNode != null)
                    {
                        Add(currentNode.key, currentNode.Value);
                        currentNode = currentNode.Next;                            
                    }
                }
            }
        }            
    }
}
