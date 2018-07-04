using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListIterrator
{
    public class ListIterator:IEnumerator<string> 
    {
        private List<string> myList;
        private int currentIndex;
        
        public ListIterator(params string[] values)
        {
            if (values.Any(x => x == null))
            {
                throw new ArgumentNullException("cannot add null");
            }
            this.myList = new List<string>(values);
            this.currentIndex = 0;
        }
  
        public bool MoveNext()
        {
            if (this.currentIndex < this.myList.Count - 1)
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.currentIndex == this.myList.Count-1)
            {
                return false;
            }

            return true;
        }

        public void Print()
        {
            if (this.myList.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation");
            }

            Console.WriteLine(this.myList[this.currentIndex]);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public string Current { get; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
