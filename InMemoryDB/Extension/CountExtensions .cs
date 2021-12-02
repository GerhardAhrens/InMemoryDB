namespace System.Collections.Generic
{
    public static class CountExtensions
    {
        public static int TryCount<T>(this IEnumerable<T> items)
        {
            if (items == null)
            {
                return 0;
            }

            switch (items)
            {
                case List<T> listCollection:
                    return listCollection.Count;
                case IList<T> ilistCollection:
                    return ilistCollection.Count;
                case ICollection<T> genCollection:
                    return genCollection.Count;
                case ICollection legacyCollection:
                    return legacyCollection.Count;
                case IReadOnlyCollection<T> roCollection:
                    return roCollection.Count;
                default:
                    return 0;
            }
        }
    }
}
