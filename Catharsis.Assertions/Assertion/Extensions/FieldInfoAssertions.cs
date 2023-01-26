using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="FieldInfo"/>
public static class FieldInfoAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="field"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Type{T}(IAssertion, FieldInfo, string)"/>
  public static IAssertion Type(this IAssertion assertion, FieldInfo field, Type type, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (field is null) throw new ArgumentNullException(nameof(field));
    if (type is null) throw new ArgumentNullException(nameof(type));

    return assertion.True(field.FieldType == type, message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="field"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="Type(IAssertion, FieldInfo, System.Type, string)"/>
  public static IAssertion Type<T>(this IAssertion assertion, FieldInfo field, string message = null) => assertion.Type(field, typeof(T), message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="field"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Private(this IAssertion assertion, FieldInfo field, string message = null) => field is not null ? assertion.True(field.IsPrivate, message) : throw new ArgumentNullException(nameof(field));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="field"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Public(this IAssertion assertion, FieldInfo field, string message = null) => field is not null ? assertion.True(field.IsPublic, message) : throw new ArgumentNullException(nameof(field));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="field"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Static(this IAssertion assertion, FieldInfo field, string message = null) => field is not null ? assertion.True(field.IsStatic, message) : throw new ArgumentNullException(nameof(field));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="field"></param>
  /// <param name="subject"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Value(this IAssertion assertion, FieldInfo field, object subject, object value, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (field is null) throw new ArgumentNullException(nameof(field));
    if (subject is null) throw new ArgumentNullException(nameof(subject));
    
    return assertion.Equal(field.GetValue(subject), value, message);
  }
}