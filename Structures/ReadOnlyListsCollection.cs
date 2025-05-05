using System.Collections;

namespace LetGetAPass.Structures
{
    public class ReadOnlyListsCollection<T> : IReadOnlyList<T>
    {
        protected readonly IReadOnlyList<T>[] baseLists;
        public ReadOnlyListsCollection(params IReadOnlyList<T>[] baseLists)
        {
            this.baseLists = baseLists;
        }

        public virtual T this[int index]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException("Index was less than 0");
                foreach (var list in baseLists)
                    if (index < list.Count)
                        return list[index];
                    else
                        index -= list.Count;
                throw new IndexOutOfRangeException("Index was more than Count");
            }
        }

        public virtual int Count
        {
            get
            {
                int count = 0;
                foreach (var collection in baseLists)
                    count += collection.Count;
                return count;
            }
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            foreach (var collection in baseLists)
                foreach (var item in collection)
                    yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}