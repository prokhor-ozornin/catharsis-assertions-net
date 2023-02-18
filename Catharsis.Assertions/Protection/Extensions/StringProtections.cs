using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="string"/> type.</para>
/// </summary>
/// <seealso cref="string"/>
public static class StringProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="text"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="text"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Empty(IProtection, StringBuilder, string)"/>
  /// <seealso cref="Empty(IProtection, SecureString, string)"/>
  /// <seealso cref="Empty(IProtection, StreamReader, string)"/>
  /// <seealso cref="Empty(IProtection, StreamWriter, string)"/>
  public static string Empty(this IProtection protection, string text, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (text is null) throw new ArgumentNullException(nameof(text));

    protection.Truth(string.IsNullOrEmpty(text), error);

    return text;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="text"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="text"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static string WhiteSpace(this IProtection protection, string text, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (text is null) throw new ArgumentNullException(nameof(text));

    protection.Truth(string.IsNullOrWhiteSpace(text), error);

    return text;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="text"></param>
  /// <param name="regex"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/>, <paramref name="text"/>, or <paramref name="regex"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static string Match(this IProtection protection, string text, Regex regex, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (text is null) throw new ArgumentNullException(nameof(text));
    if (regex is null) throw new ArgumentNullException(nameof(regex));

    protection.Truth(regex.IsMatch(text), error);

    return text;
  }
}