using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="string"/>
/// <seealso cref="StringBuilder"/>
/// <seealso cref="SecureString"/>
/// <seealso cref="StringReader"/>
/// <seealso cref="StringWriter"/>
public static class TextProtections
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
  /// <param name="builder"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="builder"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Empty(IProtection, string, string)"/>
  /// <seealso cref="Empty(IProtection, SecureString, string)"/>
  /// <seealso cref="Empty(IProtection, StreamReader, string)"/>
  /// <seealso cref="Empty(IProtection, StreamWriter, string)"/>
  public static StringBuilder Empty(this IProtection protection, StringBuilder builder, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (builder is null) throw new ArgumentNullException(nameof(builder));

    protection.Truth(builder.Length == 0, error);

    return builder;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="secure"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="secure"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Empty(IProtection, string, string)"/>
  /// <seealso cref="Empty(IProtection, StringBuilder, string)"/>
  /// <seealso cref="Empty(IProtection, StreamReader, string)"/>
  /// <seealso cref="Empty(IProtection, StreamWriter, string)"/>
  public static SecureString Empty(this IProtection protection, SecureString secure, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (secure is null) throw new ArgumentNullException(nameof(secure));

    protection.Truth(secure.Length == 0, error);

    return secure;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="reader"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="reader"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Empty(IProtection, string, string)"/>
  /// <seealso cref="Empty(IProtection, StringBuilder, string)"/>
  /// <seealso cref="Empty(IProtection, SecureString, string)"/>
  /// <seealso cref="Empty(IProtection, StreamWriter, string)"/>
  public static StreamReader Empty(this IProtection protection, StreamReader reader, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (reader is null) throw new ArgumentNullException(nameof(reader));

    protection.Truth(reader.BaseStream.Length == 0, error);

    return reader;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="writer"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="writer"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Empty(IProtection, string, string)"/>
  /// <seealso cref="Empty(IProtection, StringBuilder, string)"/>
  /// <seealso cref="Empty(IProtection, SecureString, string)"/>
  /// <seealso cref="Empty(IProtection, StreamReader, string)"/>
  public static StreamWriter Empty(this IProtection protection, StreamWriter writer, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (writer is null) throw new ArgumentNullException(nameof(writer));

    protection.Truth(writer.BaseStream.Length == 0, error);

    return writer;
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