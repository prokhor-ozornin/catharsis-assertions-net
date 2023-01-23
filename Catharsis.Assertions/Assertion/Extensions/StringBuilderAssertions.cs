using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class StringBuilderAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="builder"></param>
  /// <param name="length"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Length(this IAssertion assertion, StringBuilder builder, int length, string message = null) => builder is not null ? assertion.True(builder.Length == length, message) : throw new ArgumentNullException(nameof(builder));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="builder"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Empty(this IAssertion assertion, StringBuilder builder, string message = null) => assertion.Length(builder, 0, message);
}