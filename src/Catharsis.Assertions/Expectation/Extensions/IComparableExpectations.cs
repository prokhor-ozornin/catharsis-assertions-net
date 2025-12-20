namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="IComparable"/> types.</para>
/// </summary>
/// <seealso cref="IComparable{T}"/>
public static class IComparableExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <typeparam name="T">Type of element.</typeparam>
  extension<T>(IExpectation<T> expectation) where T : struct, IComparable<T>
  {
    /// <summary>
    ///   <para>Asserts that the given <see cref="IComparable"/> element is greater than its default value.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Negative{T}(IExpectation{T})"/>
    public IExpectation<T> Positive() => expectation.Expected(value => value.CompareTo(default) > 0);

    /// <summary>
    ///   <para>Expects that the given <see cref="IComparable"/> element is lower than its default value.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Positive{T}(IExpectation{T})"/>
    public IExpectation<T> Negative() => expectation.Expected(value => value.CompareTo(default) < 0);

    /// <summary>
    ///   <para>Expects that the given <see cref="IComparable"/> element is equal to its default value.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    public IExpectation<T> Zero() => expectation.Expected(value => value.CompareTo(default) == 0);

    /// <summary>
    ///   <para>Expects that the given <see cref="IComparable"/> element is greater than the specified value.</para>
    /// </summary>
    /// <param name="other">Expected element value for comparison.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="GreaterOrEqual{T}(IExpectation{T}, T)"/>
    public IExpectation<T> Greater(T other) => expectation.Expected(value => value.CompareTo(other) > 0);

    /// <summary>
    ///   <para>Expects that the given <see cref="IComparable"/> element is greater than or equal to the specified value.</para>
    /// </summary>
    /// <param name="other">Expected element value for comparison.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Greater{T}(IExpectation{T}, T)"/>
    public IExpectation<T> GreaterOrEqual(T other) => expectation.Expected(value => value.CompareTo(other) >= 0);

    /// <summary>
    ///   <para>Expects that the given <see cref="IComparable"/> element is lesser than the specified value.</para>
    /// </summary>
    /// <param name="other">Expected element value for comparison.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="LesserOrEqual{T}(IExpectation{T}, T)"/>
    public IExpectation<T> Lesser(T other) => expectation.Expected(value => value.CompareTo(other) < 0);

    /// <summary>
    ///   <para>Expects that the given <see cref="IComparable"/> element is lesser than or equal to the specified value.</para>
    /// </summary>
    /// <param name="other">Expected element value for comparison.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Lesser{T}(IExpectation{T}, T)"/>
    public IExpectation<T> LesserOrEqual(T other) => expectation.Expected(value => value.CompareTo(other) <= 0);

    /// <summary>
    ///   <para>Expects that the given <see cref="IComparable"/> element is within the specified range of values.</para>
    /// </summary>
    /// <param name="min">Expected range's lower bound (inclusive).</param>
    /// <param name="max">Expected range's upper bound (inclusive).</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="OutOfRange{T}(IExpectation{T}, T, T)"/>
    public IExpectation<T> InRange(T min, T max) => expectation.Expected(value => value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0);

    /// <summary>
    ///   <para>Expects that the given <see cref="IComparable"/> element is outside the specified range of values.</para>
    /// </summary>
    /// <param name="min">Expected range's lower bound (inclusive).</param>
    /// <param name="max">Expected range's upper bound (inclusive).</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="InRange{T}(IExpectation{T}, T, T)"/>
    public IExpectation<T> OutOfRange(T min, T max) => expectation.Expected(value => value.CompareTo(min) < 0 || value.CompareTo(max) > 0);
  }
}