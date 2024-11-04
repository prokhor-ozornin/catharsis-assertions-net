namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="IComparable"/> types.</para>
/// </summary>
/// <seealso cref="IComparable{T}"/>
public static class IComparableExpectations
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="IComparable"/> element is greater than its default value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="Negative{T}(IExpectation{T})"/>
  public static IExpectation<T> Positive<T>(this IExpectation<T> expectation) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(default) > 0);

  /// <summary>
  ///   <para>Expects that the given <see cref="IComparable"/> element is lower than its default value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="Positive{T}(IExpectation{T})"/>
  public static IExpectation<T> Negative<T>(this IExpectation<T> expectation) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(default) < 0);

  /// <summary>
  ///   <para>Expects that the given <see cref="IComparable"/> element is equal to its default value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<T> Zero<T>(this IExpectation<T> expectation) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(default) == 0);

  /// <summary>
  ///   <para>Expects that the given <see cref="IComparable"/> element is greater than the specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected element value for comparison.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="GreaterOrEqual{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> Greater<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) > 0);

  /// <summary>
  ///   <para>Expects that the given <see cref="IComparable"/> element is greater than or equal to the specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected element value for comparison.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="Greater{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> GreaterOrEqual<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) >= 0);

  /// <summary>
  ///   <para>Expects that the given <see cref="IComparable"/> element is lesser than the specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected element value for comparison.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="LesserOrEqual{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> Lesser<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) < 0);

  /// <summary>
  ///   <para>Expects that the given <see cref="IComparable"/> element is lesser than or equal to the specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="other">Expected element value for comparison.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="Lesser{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> LesserOrEqual<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) <= 0);

  /// <summary>
  ///   <para>Expects that the given <see cref="IComparable"/> element is within the specified range of values.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="min">Expected range's lower bound (inclusive).</param>
  /// <param name="max">Expected range's upper bound (inclusive).</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="OutOfRange{T}(IExpectation{T}, T, T)"/>
  public static IExpectation<T> InRange<T>(this IExpectation<T> expectation, T min, T max) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0);

  /// <summary>
  ///   <para>Expects that the given <see cref="IComparable"/> element is outside the specified range of values.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="min">Expected range's lower bound (inclusive).</param>
  /// <param name="max">Expected range's upper bound (inclusive).</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="InRange{T}(IExpectation{T}, T, T)"/>
  public static IExpectation<T> OutOfRange<T>(this IExpectation<T> expectation, T min, T max) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(min) < 0 || value.CompareTo(max) > 0);
}