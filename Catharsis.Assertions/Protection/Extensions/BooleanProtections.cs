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
  /// <param name="protection">Protection to perform.</param>
  /// <param name="expression"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Lie(IProtection, bool, string)"/>
  public static void Truth(this IProtection protection, bool expression, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (expression)
    {
      throw new ArgumentException(error);
    }
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="expression"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Truth(IProtection, bool, string)"/>
  public static void Lie(this IProtection protection, bool expression, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (!expression)
    {
      throw new ArgumentException(error);
    }
  }
}