using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="PropertyInfo"/> type.</para>
/// </summary>
/// <seealso cref="PropertyInfo"/>
public static class PropertyInfoAssertions
{
  /// <param name="assertion">Assertion to validate.</param>
  extension(IAssertion assertion)
  {
    /// <summary>
    ///   <para>Asserts that the given <see cref="PropertyInfo"/> represents a readable property.</para>
    /// </summary>
    /// <param name="property">Object property to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="property"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    /// <seealso cref="Writable(IAssertion, PropertyInfo, string)"/>
    public IAssertion Readable(PropertyInfo property, string error = null) => property is not null ? assertion.True(property.CanRead, error) : throw new ArgumentNullException(nameof(property));

    /// <summary>
    ///   <para>Asserts that the given <see cref="PropertyInfo"/> represents a read-only property.</para>
    /// </summary>
    /// <param name="property">Object property to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="property"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion ReadOnly(PropertyInfo property, string error = null) => property is not null ? assertion.True(property.CanRead && !property.CanWrite, error) : throw new ArgumentNullException(nameof(property));

    /// <summary>
    ///   <para>Asserts that the given <see cref="PropertyInfo"/> represents a writable property.</para>
    /// </summary>
    /// <param name="property">Object property to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="property"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    /// <seealso cref="Readable(IAssertion, PropertyInfo, string)"/>
    public IAssertion Writable(PropertyInfo property, string error = null) => property is not null ? assertion.True(property.CanWrite, error) : throw new ArgumentNullException(nameof(property));

    /// <summary>
    ///   <para>Asserts that the given <see cref="PropertyInfo"/> represents a write-only property.</para>
    /// </summary>
    /// <param name="property">Object property to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="property"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion WriteOnly(PropertyInfo property, string error = null) => property is not null ? assertion.True(property.CanWrite && !property.CanRead, error) : throw new ArgumentNullException(nameof(property));

    /// <summary>
    ///   <para>Asserts that the given <see cref="PropertyInfo"/> represents a property with the specified value.</para>
    /// </summary>
    /// <param name="property">Object property to inspect.</param>
    /// <param name="subject">Target object.</param>
    /// <param name="value">Asserted property value.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="property"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Value(PropertyInfo property, object subject, object value, string error = null)
    {
      if (assertion is null) throw new ArgumentNullException(nameof(assertion));
      if (property is null) throw new ArgumentNullException(nameof(property));

      return assertion.Equal(property.GetValue(subject), value, error);
    }
  }
}