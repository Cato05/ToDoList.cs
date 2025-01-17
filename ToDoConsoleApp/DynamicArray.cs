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
        public int capacity = 5;
        string[] array = new string[5];



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
            
                for (int i = size; i > index; i--)
                {
                    array[i] = array[i - 1];

                }
                array[index] = data.ToLower();
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
            int newCapacity = (int)(capacity * 2);
            string[] tempArray = new string[newCapacity];

            for (int i = 0; i < size; i++)
            {
                tempArray[i] = array[i];
            }
            capacity = newCapacity;
            array = tempArray;
        }

        private void shrink() {
            int newCapacity = (int)(capacity / 2);
            string[] tempArray = new string[newCapacity];

            for (int i = 0; i < size; i++)
            {
                tempArray[i] = array[i];
            }
            capacity = newCapacity;
            array = tempArray;
        }

        public bool thisEmpty()
        {
            return size == 0;
        }

        public string ListAll()
        {
            string DevString = string.Empty;
            string UserString = string.Empty;

            for(int i = 0; i < size; i++)
            {
                DevString += array[i] + ", ";
                UserString += array[i] + "\n";
                
            }
            if (DevString != string.Empty || UserString != string.Empty)
            {
                UserString = UserString.Substring(0, UserString.Length - 1);
               DevString = '[' + DevString.Substring(0, DevString.Length - 2) + ']'; //Removing the comma, from the end, adding '[' and ']'
            }
            else
            {
               DevString = "[]";
                UserString = "[]";
            }
            return UserString;
        }


    }
}
