
namespace Examples.Collections.Classes
{
    interface IEnumerator { }
    interface IEnumerable { }
    interface ICollection : IEnumerable{ }
    interface IList: ICollection { }
    interface IDictionary : ICollection { }
    interface ISet : ICollection { }

    struct KeyValuePair { }
    class SortedSet : ISet { }
    class HashSet : ISet { }
    class Dictionary : IDictionary { }
    class List : IList { }
    class Stack : IEnumerable { }
    class Queue : IEnumerable { }
    class LinkedList : ICollection { }
    interface IComparer { }





}
