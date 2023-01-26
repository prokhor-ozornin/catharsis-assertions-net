namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class EnumerableProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="sequence"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IEnumerable<T> Empty<T>(this IProtection protection, IEnumerable<T> sequence, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (sequence is null) throw new ArgumentNullException(message);

    if (!sequence.Any())
    {
      throw new ArgumentException(message);
    }

    return sequence;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <param name="values"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T AnyOf<T>(this IProtection protection, T value, string message = null, IEnumerable<T> values = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (values is null) return value;

    if (values.Contains(value))
    {
      throw new ArgumentException(message);
    }

    return value;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <param name="values"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T AnyOf<T>(this IProtection protection, T value, string message = null, params T[] values) => protection.AnyOf(value, message, values as IEnumerable<T>);
}