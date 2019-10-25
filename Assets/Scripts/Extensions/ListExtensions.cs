using System.Collections.Generic;

public static class ListExtensions
{
    /// <summary>
    /// Gets the next element in a list including cycling back to the 0th element if at the end of the list.
    /// </summary>
    /// <returns>The next element in the cycle.</returns>
    public static TElement GetNextInCycle<TElement>(this List<TElement> list, TElement element, bool reverse = false)
    {
        int currentIndex = list.IndexOf(element);
        int nextIndex = (reverse ? list.Count + currentIndex - 1 : currentIndex + 1) % list.Count;
        return list[nextIndex];
    }
}
