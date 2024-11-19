using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoConsoleApp
{
    internal class DynamicArray
    {
        public int size = 0;
        public int capacity = 10;
        string[] array = new string[10];



        public void Add(string data)
        {
            if (size >= capacity)
            {
                grow();
            }
            
            array[size] = data.ToLower();
            size++;
        }

        public void Insert(int index, string data)
        {
            if (size >= capacity)
            {
                grow();
            }
            else if (array[index] != null)
            {
                for (int i = size; i > index; i--)
                {
                    array[i] = array[i-1];
                    array[i-1] = null;
                }
            }
            array[index] = data;
            size++;
        }

        public void delete(string data)
        {
            data = data.ToLower();
            for (int i = 0; i < size; i++)
            {
                if (array[i] == data)
                {
                    
                    for (int j = i; j < size; j++)
                    {
                        array[j] = array[j+1];
                    }
                    
                }
                size--;
                if (size <= (int)(capacity / 3))
                {
                    shrink();
                }
                break;

            }

            

        }

        public int search(string data) {

            data = data.ToLower();
            for (int i = 0; i < size; i++)
            {
                if (array[i] == data)
                    return i;
            }
            return -1;
        }

        private void grow()
        {

        }

        private void shrink() { 
        
        }

        public bool thisEmpty()
        {
            return size == 0;
        }

        public string ListAll()
        {
            string String = string.Empty;

            for(int i = 0; i < size; i++)
            {
                String += array[i] + ", ";
            }
            if (String != string.Empty)
            {
               String = '[' + String.Substring(0, String.Length - 2) + ']'; //Removing the comma, from the end, adding '[' and ']'
            }
            else
            {
               String = "[]";
            }
            return String;
        }

    }
}
