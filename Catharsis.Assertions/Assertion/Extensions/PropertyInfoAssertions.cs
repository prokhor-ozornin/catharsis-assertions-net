using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="PropertyInfo"/> type.</para>
/// </summary>
/// <seealso cref="PropertyInfo"/>
public static class PropertyInfoAssertions
{
  /// <summary>
  ///   <para>Asserts that a given object property can be read.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="property">Object property to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="property"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Writable(IAssertion, PropertyInfo, string)"/>
  public static IAssertion Readable(this IAssertion assertion, PropertyInfo property, string error = null) => property is not null ? assertion.True(property.CanRead, error) : throw new ArgumentNullException(nameof(property));

  /// <summary>
  ///   <para>Asserts that a given object property is read-only (cannot be written to).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="property">Object property to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="property"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ReadOnly(this IAssertion assertion, PropertyInfo property, string error = null) => property is not null ? assertion.True(property.CanRead && !property.CanWrite, error) : throw new ArgumentNullException(nameof(property));

  /// <summary>
  ///   <para>Asserts that a given object property can be written to.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="property">Object property to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="property"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Readable(IAssertion, PropertyInfo, string)"/>
  public static IAssertion Writable(this IAssertion assertion, PropertyInfo property, string error = null) => property is not null ? assertion.True(property.CanWrite, error) : throw new ArgumentNullException(nameof(property));

  /// <summary>
  ///   <para>Asserts that a given object property is write-only (cannot be read).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="property">Object property to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="property"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion WriteOnly(this IAssertion assertion, PropertyInfo property, string error = null) => property is not null ? assertion.True(property.CanWrite && !property.CanRead, error) : throw new ArgumentNullException(nameof(property));

  /// <summary>
  ///   <para>Asserts that a given object property has a specified value.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="property">Object property to inspect.</param>
  /// <param name="subject">Target object.</param>
  /// <param name="value">Property value to check for.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="property"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Value(this IAssertion assertion, PropertyInfo property, object subject, object value, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (property is null) throw new ArgumentNullException(nameof(property));

    return assertion.Equal(property.GetValue(subject), value, error);
  }
}