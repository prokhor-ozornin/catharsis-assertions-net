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
  /// <param name="protection"></param>
  /// <param name="text"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static string Empty(this IProtection protection, string text, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (text is null) throw new ArgumentNullException(nameof(text));

    protection.Truth(string.IsNullOrEmpty(text), message);

    return text;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="builder"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static StringBuilder Empty(this IProtection protection, StringBuilder builder, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (builder is null) throw new ArgumentNullException(nameof(builder));

    protection.Truth(builder.Length == 0, message);

    return builder;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="secure"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static SecureString Empty(this IProtection protection, SecureString secure, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (secure is null) throw new ArgumentNullException(nameof(secure));

    protection.Truth(secure.Length == 0, message);

    return secure;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="reader"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static StreamReader Empty(this IProtection protection, StreamReader reader, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (reader is null) throw new ArgumentNullException(nameof(reader));

    protection.Truth(reader.BaseStream.Length == 0, message);

    return reader;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="writer"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static StreamWriter Empty(this IProtection protection, StreamWriter writer, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (writer is null) throw new ArgumentNullException(nameof(writer));

    protection.Truth(writer.BaseStream.Length == 0, message);

    return writer;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="text"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static string WhiteSpace(this IProtection protection, string text, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (text is null) throw new ArgumentNullException(nameof(text));

    protection.Truth(string.IsNullOrWhiteSpace(text), message);

    return text;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection"></param>
  /// <param name="text"></param>
  /// <param name="regex"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static string Match(this IProtection protection, string text, Regex regex, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (text is null) throw new ArgumentNullException(nameof(text));
    if (regex is null) throw new ArgumentNullException(nameof(regex));

    protection.Truth(regex.IsMatch(text), message);

    return text;
  }
}