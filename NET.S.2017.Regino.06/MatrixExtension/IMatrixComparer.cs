namespace MatrixExtension
{
    /// <summary>
    /// Interface to imlement benchmark.
    /// </summary>
    public interface IMatrixComparer
    {
        /// <summary>
        /// Compare two arrays.
        /// </summary>
        /// <param name="lhs">First array.</param>
        /// <param name="rhs">Second array.</param>
        /// <returns></returns>
        int Comparer(int[] lhs, int[] rhs);
    }
}
