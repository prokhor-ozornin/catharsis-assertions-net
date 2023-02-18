namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for comparable types.</para>
/// </summary>
/// <seealso cref="IComparable{T}"/>
public static class IComparableExpectations
{
  /// <summary>
  ///   <para>Expects that a given comparable element is "positive" (higher than its default value).</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Negative{T}(IExpectation{T})"/>
  public static IExpectation<T> Positive<T>(this IExpectation<T> expectation) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(default) > 0);

  /// <summary>
  ///   <para>Expects that a given comparable element is "negative" (lower than its default value).</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Positive{T}(IExpectation{T})"/>
  public static IExpectation<T> Negative<T>(this IExpectation<T> expectation) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(default) < 0);

  /// <summary>
  ///   <para>Expects that a given comparable element is "zero" (equal to its default value).</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<T> Zero<T>(this IExpectation<T> expectation) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(default) == 0);

  /// <summary>
  ///   <para>Expects that a given comparable element is greater than a specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="GreaterOrEqual{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> Greater<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) > 0);

  /// <summary>
  ///   <para>Expects that a given comparable element is greater than or equal to a specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Greater{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> GreaterOrEqual<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) >= 0);

  /// <summary>
  ///   <para>Expects that a given comparable element is lesser than a specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="LesserOrEqual{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> Lesser<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) < 0);

  /// <summary>
  ///   <para>Expects that a given comparable element is lesser than or equal to a specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="other"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Lesser{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> LesserOrEqual<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) <= 0);

  /// <summary>
  ///   <para>Expects that a given comparable element lies within a specified range of values.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="min"></param>
  /// <param name="max"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="OutOfRange{T}(IExpectation{T}, T, T)"/>
  public static IExpectation<T> InRange<T>(this IExpectation<T> expectation, T min, T max) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0);

  /// <summary>
  ///   <para>Expects that a given comparable element lies out of a specified range of values.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="min">Lower bound of the range (inclusive).</param>
  /// <param name="max">Upper bound of the range (inclusive).</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="InRange{T}(IExpectation{T}, T, T)"/>
  public static IExpectation<T> OutOfRange<T>(this IExpectation<T> expectation, T min, T max) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(min) < 0 || value.CompareTo(max) > 0);
}