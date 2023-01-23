using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class PropertyInfoAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="property"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Readable(this IAssertion assertion, PropertyInfo property, string message = null) => property is not null ? assertion.True(property.CanRead, message) : throw new ArgumentNullException(nameof(property));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="property"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Writable(this IAssertion assertion, PropertyInfo property, string message = null) => property is not null ? assertion.True(property.CanWrite, message) : throw new ArgumentNullException(nameof(property));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="property"></param>
  /// <param name="subject"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Value(this IAssertion assertion, PropertyInfo property, object subject, object value, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (property is null) throw new ArgumentNullException(nameof(property));
    if (subject is null) throw new ArgumentNullException(nameof(subject));

    return assertion.Equal(property.GetValue(subject), value, message);
  }
}