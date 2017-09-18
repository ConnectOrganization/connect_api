namespace Sorting
{
    public class SortingElement
    {
        private const Sorting Asc = Sorting.Asc;
        private const Sorting Desc = Sorting.Dsc;

        private readonly string _orderBy;
        private readonly Sorting _direction;

        public SortingElement(string orderBy, Sorting direction)
        {
            _orderBy = orderBy;
            _direction = direction;
        }

        public bool IsAsc()
        {
            return Asc.Equals(_direction);
        }

        public string GetOrderBy()
        {
            return _orderBy;
        }
    }
}