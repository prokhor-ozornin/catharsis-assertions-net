namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IComparable{T}"/>
public static class ComparableAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Negative{T}(IAssertion, T, string)"/>
  public static IAssertion Positive<T>(this IAssertion assertion, T value, string message = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(default) > 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Positive{T}(IAssertion, T, string)"/>
  public static IAssertion Negative<T>(this IAssertion assertion, T value, string message = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(default) < 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Zero<T>(this IAssertion assertion, T value, string message = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(default) == 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="value"></param>
  /// <param name="other"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="GreaterOrEqual{T}(IAssertion, T, T, string)"/>
  public static IAssertion Greater<T>(this IAssertion assertion, T value, T other, string message = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(other) > 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="value"></param>
  /// <param name="other"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Greater{T}(IAssertion, T, T, string)"/>
  public static IAssertion GreaterOrEqual<T>(this IAssertion assertion, T value, T other, string message = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(other) >= 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="value"></param>
  /// <param name="other"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="LesserOrEqual{T}(IAssertion, T, T, string)"/>
  public static IAssertion Lesser<T>(this IAssertion assertion, T value, T other, string message = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(other) < 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="value"></param>
  /// <param name="other"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Lesser{T}(IAssertion, T, T, string)"/>
  public static IAssertion LesserOrEqual<T>(this IAssertion assertion, T value, T other, string message = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(other) <= 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="value"></param>
  /// <param name="min"></param>
  /// <param name="max"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  /// <seealso cref="OutOfRange{T}(IAssertion, T, T, T, string)"/>
  public static IAssertion InRange<T>(this IAssertion assertion, T value, T min, T max, string message = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="value"></param>
  /// <param name="min"></param>
  /// <param name="max"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  /// <seealso cref="InRange{T}(IAssertion, T, T, T, string)"/>
  public static IAssertion OutOfRange<T>(this IAssertion assertion, T value, T min, T max, string message = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(min) < 0 || value.CompareTo(max) > 0, message);
}