using System;
using System.Collections.Generic;

namespace Sorting
{
    public class SortingInfo
    {
        private readonly List<SortingElement> _ordering = new List<SortingElement>();

        /** delegate method from ordering */
        public void Add(string orderBy, Sorting direction)
        {
            Add(new SortingElement(orderBy, direction));
        }

        public void Add(SortingElement sortingElement)
        {
            _ordering.Add(sortingElement);
        }

        public void InsertAtIndex(int index, string orderBy, Sorting direction)
        {
            _ordering.Insert(index, new SortingElement(orderBy, direction));
        }

        /** delegate method from ordering */
        public int Size()
        {
            return _ordering.Count;
        }

        /**implemention of Iterable */
        public List<SortingElement> Iterator()
        {
            return _ordering;
        }

        public static SortingInfo Parse(string sortingHeader)
        {
            if (sortingHeader == null)
                return null;

            var sorting = new SortingInfo();

            var keys = sortingHeader.Split(';');

            foreach (var key in keys)
            {
                if (!key.EndsWith("_asc") && !key.EndsWith("_dsc"))
                    throw new InvalidOperationException("Sorting Header mal formed for sorting");

                var values = key.Split('_');
                var direction = values[1].ToLower().Equals("asc") ? Sorting.Asc : Sorting.Dsc;
                var orderBy = values[0]; // no IndexOutOfBoundsException is raised
                sorting.Add(orderBy, direction);
            }

            return sorting;
        }
    }
}