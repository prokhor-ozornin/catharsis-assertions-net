using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="FieldInfo"/> type.</para>
/// </summary>
/// <seealso cref="FieldInfo"/>
public static class FieldInfoAssertions
{
  /// <summary>
  ///   <para>Asserts that a given object field is of specified type.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="field">Object field to inspect.</param>
  /// <param name="type">Type of field to check for.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="field"/>, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Type{T}(IAssertion, FieldInfo, string)"/>
  public static IAssertion Type(this IAssertion assertion, FieldInfo field, Type type, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (field is null) throw new ArgumentNullException(nameof(field));
    if (type is null) throw new ArgumentNullException(nameof(type));

    return assertion.True(field.FieldType == type, error);
  }

  /// <summary>
  ///   <para>Asserts that a given object field is of specified type.</para>
  /// </summary>
  /// <typeparam name="T">Type of field to check for.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="field">Object field to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="field"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Type(IAssertion, FieldInfo, System.Type, string)"/>
  public static IAssertion Type<T>(this IAssertion assertion, FieldInfo field, string error = null) => assertion.Type(field, typeof(T), error);

  /// <summary>
  ///   <para>Asserts that a given object field is of <see langword="private"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="field">Object field to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="field"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Private(this IAssertion assertion, FieldInfo field, string error = null) => field is not null ? assertion.True(field.IsPrivate, error) : throw new ArgumentNullException(nameof(field));

  /// <summary>
  ///   <para>Asserts that a given object field is of <see langword="protected"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="field">Object field to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="field"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Protected(this IAssertion assertion, FieldInfo field, string error = null) => field is not null ? assertion.True(field.IsFamily, error) : throw new ArgumentNullException(nameof(field));

  /// <summary>
  ///   <para>Asserts that a given object field is of <see langword="public"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="field">Object field to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="field"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Public(this IAssertion assertion, FieldInfo field, string error = null) => field is not null ? assertion.True(field.IsPublic, error) : throw new ArgumentNullException(nameof(field));

  /// <summary>
  ///   <para>Asserts that a given object field is of <see langword="internal"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="field">Object field to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="field"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Internal(this IAssertion assertion, FieldInfo field, string error = null) => field is not null ? assertion.True(field.IsAssembly, error) : throw new ArgumentNullException(nameof(field));

  /// <summary>
  ///   <para>Asserts that a given object field is of <see langword="protected internal"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="field">Object field to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="field"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ProtectedInternal(this IAssertion assertion, FieldInfo field, string error = null) => field is not null ? assertion.True(field.IsFamilyOrAssembly, error) : throw new ArgumentNullException(nameof(field));

  /// <summary>
  ///   <para>Asserts that a given object field is <see langword="static"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="field">Object field to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="field"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Static(this IAssertion assertion, FieldInfo field, string error = null) => field is not null ? assertion.True(field.IsStatic, error) : throw new ArgumentNullException(nameof(field));

  /// <summary>
  ///   <para>Asserts that a given object field has a specified value.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="field">Object field to inspect.</param>
  /// <param name="subject">Target object.</param>
  /// <param name="value">Asserted field value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="field"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Value(this IAssertion assertion, FieldInfo field, object subject, object value, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (field is null) throw new ArgumentNullException(nameof(field));
    
    return assertion.Equal(field.GetValue(subject), value, error);
  }
}