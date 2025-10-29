using System.Collections;
using System.Collections.Generic;

namespace NonGenericCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList
            ArrayList arrlst = new ArrayList();

            //.Add() method adds the element
            arrlst.Add(1);
            arrlst.Add(2);
            arrlst.Add("junaid");
            arrlst.Add(false);
            arrlst.Add(1.02);
            int capacity = arrlst.Capacity;//property to check the capacity of the arraylist
            int count = arrlst.Count;//property to count the number of the elements present in the arraylist

            //System.Console.WriteLine($"Capacity of array list is {capacity}");
            //System.Console.WriteLine($"Number of elements present in the arraylist is {count}");
            //for (int i = 0; i < count; i++)
            //{
            //    System.Console.WriteLine(arrlst[i]);
            //}

            ////.reverse() reverses the count of the array list
            //arrlst.Reverse();
            //for (int i = 0; i < count; i++)
            //{
            //    System.Console.WriteLine(arrlst[i]);
            //}

            ////Sets the capacity to actual number of the elements
            //arrlst.TrimToSize();

            ////returns the index of first occurance of that element
            //System.Console.WriteLine(arrlst.IndexOf("junaid"));
            ////returns the index of last occurance of that element
            //System.Console.WriteLine(arrlst.LastIndexOf("junaid"));

            ////returns boolean value if array has that element
            //arrlst.Contains(2);

            ////inserts (at the index, mentioned item)  
            //arrlst.Insert(2, "safwan");
            //inserts (at the index, other list)
            //arrlst.InsertRange(0, arrlst2);
            //foreach (object item in arrlst)
            //{
            //    System.Console.WriteLine(item);
            //}

            ////removes the element at that index 
            //arrlst.RemoveAt(4);

            ////removes the first occurance of the element from the list
            //arrlst.Remove("safwan");

            
            int[] newValues = { 10, 20, 30 };

            ////adds the elements to the end of the array list
            //arrlst.AddRange(newValues);

            //index → the starting position in the target ArrayList.
            //c → the collection whose elements you want to copy into the ArrayList.
            //.SetRange(index, c);
            //arrlst.SetRange(4, newValues);

            ////returns a subset list of elements (starting at, number of elements)
            //arrlst.GetRange(2, 3);

            ////removes a subset list of elements (starting at, number of elements)
            //arrlst.RemoveRange(0, count);

            ////clones the arraylist into a new arraylist
            //ArrayList arrlst3 = (ArrayList)arrlst.Clone();

            ////wipes out all the element
            //arrlst.Clear();



            SortedList srtdlst = new SortedList();
            srtdlst.Add(1,"junaid");
            srtdlst.Add(2,"mango");
            srtdlst.Add(3, 1234);
            srtdlst.Add(4, false);
            srtdlst.Add(5, 3.25);
            srtdlst.Add(6, 'c');
            srtdlst.Add(7, arrlst);
            srtdlst.Add(8, newValues);

            srtdlst[9] = "added"; //add if key not present
            srtdlst[9] = "aabhas";//update if key present

            //foreach (DictionaryEntry item in srtdlst)
            //{
            //    Console.Write(item.Key + ":");
            //    Console.WriteLine(item.Value);
            //}

            //Console.WriteLine(srtdlst.GetByIndex(0)); //gets value at index
            //Console.WriteLine(srtdlst.GetKey(0));//gets key at index 

            //IList keys = srtdlst.GetKeyList(); //gets a list of all the keys
            //IList values = srtdlst.GetValueList(); //gets the list of all the values

            //Console.WriteLine(srtdlst.IndexOfKey(1));//gets index from key
            //Console.WriteLine(srtdlst.IndexOfValue("Junaid"));//gets index at value 
            //objDictionary.SetByIndex(1,arsalan);//sets the value to the index
            
            //ICollection keys = srtdlst.Keys;
            //// Keys
            //Console.WriteLine("Keys:");
            //foreach (var key in srtdlst.Keys)
            //{
            //    Console.WriteLine(key);
            //}

            //// Values
            //ICollection values = srtdlst.Values;
            //Console.WriteLine("\nValues:");
            //foreach (var value in srtdlst.Values)
            //{
            //    Console.WriteLine(value);
            //}

            //and all the methods discussed for array list
        }
    }
}
