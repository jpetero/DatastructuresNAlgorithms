//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DataStructures.HashMaps
//{
//    class HashMap
//    {
//        private const int TABLE_SIZE = 1000;
        
//        // Entry from the user
//        private class Node
//        {
//            string Key;
//            int Value;
//            Node Next;
//            //public Node(string key, int value)
//            //{
//            //    Key = key;
//            //    Value = value;
//            //}
//        }

//        private class HashTable
//        {
//            public Node Entries;
//        }

//        private HashTable CreateHashTable()
//        {
//            // Create hash table
//            HashTable hashTable = new HashTable();

//            // Create table entries
//            hashTable.Entries = new Node() * TABLE_SIZE;
//        }
        
//        public static int hash(string key)
//        {
//            int value = 0;
//            for (int i = 0; i < key.Length; i++)
//            {
//                value = value * 37 + key[i];
//            }
//            // Make sure 0 <= value < TABLE_SIZE
//            value = value % TABLE_SIZE;
//            return value;
//        }
//    }
//}
