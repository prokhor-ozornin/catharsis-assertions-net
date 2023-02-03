namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="bool"/>
public static class BooleanProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="expression"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static void Truth(this IProtection protection, bool expression, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (expression)
    {
      throw new ArgumentException(message);
    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="expression"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static void Lie(this IProtection protection, bool expression, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (!expression)
    {
      throw new ArgumentException(message);
    }
  }
}