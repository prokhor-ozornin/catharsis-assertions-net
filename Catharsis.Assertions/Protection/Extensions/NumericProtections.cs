namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class NumericProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T Positive<T>(this IProtection protection, T value, string message = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (value.CompareTo(default) >= 0)
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
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T Negative<T>(this IProtection protection, T value, string message = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (value.CompareTo(default) <= 0)
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
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T Zero<T>(this IProtection protection, T value, string message = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (value.CompareTo(default) == 0)
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
  /// <param name="min"></param>
  /// <param name="max"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  public static T OutOfRange<T>(this IProtection protection, T value, T min, T max, string message = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
    {
      throw new ArgumentOutOfRangeException(message);
    }

    return value;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="value"></param>
  /// <param name="range"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static int OutOfRange(this IProtection protection, int value, Range range, string message = null) => protection.OutOfRange(value, range.Start.Value, range.End.Value, message);
}