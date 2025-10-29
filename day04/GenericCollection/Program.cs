namespace GenericCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Generic collections works only with datatype mentioned inside <>

            //ArrayList are called List in generic collection
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);    
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);

            //all the methods that works with array list

            //hashmaps are called Dictionary in Generic collection 
            //sorted list remains sorted list in generic collection too.
            SortedList<int, string> lst = new SortedList<int, string>();
            lst.Add(1, "Junaid");
            lst.Add(2, "Safwan");
            lst.Add(3, "Arsalan");
            //all the methods from sortedlist in non generic collection



            //Generic collection also provides Sorted Dictionaries.
            //similarities:
            //SortedList<TKey,TValue> and SortedDictionary<TKey,TValue >
            //belong to the System.Collections.Generic namespace.

            //Both:
            //Store key–value pairs(like a dictionary).
            //Automatically keep keys in sorted order(ascending by default).
            //Require unique keys.
            //Support key-based lookup, add, remove, and enumeration.

            //But they differ in how they are implemented and perform internally.

            //1. Internal Implementation
            //Collection                        Internal Structure                                          Description
            //SortedList<TKey, TValue>          Backed by two arrays(one for keys, one for values).	        Uses binary search for lookups and array shifting for insert/remove.
            //SortedDictionary<TKey, TValue>    Backed by a balanced binary search tree(Red-Black Tree).	Insertions, deletions, and lookups are more balanced in performance.

            //2. Performance Comparison
            //Operation                         SortedList                                              SortedDictionary
            //Lookup(ContainsKey / Indexer)     O(log n)                                                O(log n)
            //Insert / Remove                   O(n) (because arrays may need shifting)	                O(log n) (tree insert/remove)
            //Memory Usage                      Lower(arrays are compact)                               Higher(tree nodes use extra memory)
            //Index-based Access                ✅ Yes(you can access by index: myList.Keys[i])        ❌ No index-based access
            //Enumeration Speed                 Faster(data stored contiguously in arrays)              Slower(traverses tree structure)

            //3.Use Case                                                    Best Choice
            //If your data is mostly read - only after creation	          ✅ SortedList
            //If you need index - based access(like myList.Keys[0])       ✅ SortedList
            //If you frequently add or remove items dynamically           ✅ SortedDictionary
            //If you need consistent performance for large dynamic data   ✅ SortedDictionary

        }
    }
}
