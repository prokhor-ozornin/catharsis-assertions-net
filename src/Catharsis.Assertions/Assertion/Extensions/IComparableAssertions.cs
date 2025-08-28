namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for <see cref="IComparable"/> types.</para>
/// </summary>
/// <seealso cref="IComparable{T}"/>
public static class IComparableAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="IComparable"/> element is greater than its default value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="comparable">Element to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Negative{T}(IAssertion, T, string)"/>
  public static IAssertion Positive<T>(this IAssertion assertion, T comparable, string error = null) where T : struct, IComparable<T> => assertion.True(comparable.CompareTo(default) > 0, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="IComparable"/> element is lower than its default value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="comparable">Element to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Positive{T}(IAssertion, T, string)"/>
  public static IAssertion Negative<T>(this IAssertion assertion, T comparable, string error = null) where T : struct, IComparable<T> => assertion.True(comparable.CompareTo(default) < 0, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="IComparable"/> element is equal to its default value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="comparable">Element to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Zero<T>(this IAssertion assertion, T comparable, string error = null) where T : struct, IComparable<T> => assertion.True(comparable.CompareTo(default) == 0, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="IComparable"/> element is greater than the specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="left">Element to inspect.</param>
  /// <param name="right">Asserted element value for comparison.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <seealso cref="GreaterOrEqual{T}(IAssertion, T, T, string)"/>
  public static IAssertion Greater<T>(this IAssertion assertion, T left, T right, string error = null) where T : struct, IComparable<T> => assertion.True(left.CompareTo(right) > 0, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="IComparable"/> element is greater than or equal to the specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="left">Element to inspect.</param>
  /// <param name="right">Asserted element value for comparison.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Greater{T}(IAssertion, T, T, string)"/>
  public static IAssertion GreaterOrEqual<T>(this IAssertion assertion, T left, T right, string error = null) where T : struct, IComparable<T> => assertion.True(left.CompareTo(right) >= 0, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="IComparable"/> element is lesser than the specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="left">Element to inspect.</param>
  /// <param name="right">Asserted element value for comparison.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="LesserOrEqual{T}(IAssertion, T, T, string)"/>
  public static IAssertion Lesser<T>(this IAssertion assertion, T left, T right, string error = null) where T : struct, IComparable<T> => assertion.True(left.CompareTo(right) < 0, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="IComparable"/> element is lesser than or equal to the specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="left">Element to inspect.</param>
  /// <param name="right">Asserted element value for comparison.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Lesser{T}(IAssertion, T, T, string)"/>
  public static IAssertion LesserOrEqual<T>(this IAssertion assertion, T left, T right, string error = null) where T : struct, IComparable<T> => assertion.True(left.CompareTo(right) <= 0, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="IComparable"/> element is within the specified range of values.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="comparable">Element to inspect.</param>
  /// <param name="min">Asserted range's lower bound (inclusive).</param>
  /// <param name="max">Asserted range's upper bound (inclusive).</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="OutOfRange{T}(IAssertion, T, T, T, string)"/>
  public static IAssertion InRange<T>(this IAssertion assertion, T comparable, T min, T max, string error = null) where T : struct, IComparable<T> => assertion.True(comparable.CompareTo(min) >= 0 && comparable.CompareTo(max) <= 0, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="IComparable"/> element is outside the specified range of values.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="comparable">Element to inspect.</param>
  /// <param name="min">Asserted range's lower bound (inclusive).</param>
  /// <param name="max">Asserted range's upper bound (inclusive).</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="InRange{T}(IAssertion, T, T, T, string)"/>
  public static IAssertion OutOfRange<T>(this IAssertion assertion, T comparable, T min, T max, string error = null) where T : struct, IComparable<T> => assertion.True(comparable.CompareTo(min) < 0 || comparable.CompareTo(max) > 0, error);
}