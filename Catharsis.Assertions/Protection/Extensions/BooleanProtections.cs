namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for the <see cref="bool"/> type.</para>
/// </summary>
/// <seealso cref="bool"/>
public static class BooleanProtections
{
  /// <summary>
  ///   <para>This function protects the given boolean expression from becoming <see langword="true"/>, ensuring that it remains <see langword="false"/>.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="expression">Protected boolean expression.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
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
  ///   <para>This function protects the given boolean expression from becoming <see langword="false"/>, ensuring that it remains <see langword="true"/>.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="expression">Protected boolean expression.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
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