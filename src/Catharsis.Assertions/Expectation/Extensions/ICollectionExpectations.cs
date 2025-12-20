namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="ICollection{T}"/> types.</para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
public static class ICollectionExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <typeparam name="T">The type of elements in the collection.</typeparam>
  extension<T>(IExpectation<ICollection<T>> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="ICollection{T}"/> has a specified number of elements.</para>
    /// </summary>
    /// <param name="count">Expected number of elements.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<ICollection<T>> Count(int count) => expectation.HaveSubject().And().Expected(collection => collection.Count == count);

    /// <summary>
    ///   <para>Expects that the given <see cref="ICollection{T}"/> is empty, meaning it contains no elements.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<ICollection<T>> Empty() => expectation.Count(0);

    /// <summary>
    ///   <para>Expects that the given <see cref="ICollection{T}"/> is read-only.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<ICollection<T>> ReadOnly() => expectation.HaveSubject().And().Expected(collection => collection.IsReadOnly);
  }
}