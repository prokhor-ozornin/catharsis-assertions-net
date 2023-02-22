using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="FieldInfo"/> type.</para>
/// </summary>
/// <seealso cref="FieldInfo"/>
public static class FieldInfoExpectations
{
  /// <summary>
  ///   <para>Expects that a given object field is of specified type.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="type">Type of field to check for.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Type{T}(IExpectation{FieldInfo})"/>
  public static IExpectation<FieldInfo> Type(this IExpectation<FieldInfo> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(field => field.FieldType == type);

  /// <summary>
  ///   <para>Expects that a given object field is of specified type.</para>
  /// </summary>
  /// <typeparam name="T">Type of field to check for.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Type(IExpectation{FieldInfo}, System.Type)"/>
  public static IExpectation<FieldInfo> Type<T>(this IExpectation<FieldInfo> expectation) => expectation.Type(typeof(T));

  /// <summary>
  ///   <para>Expects that a given object field is of <see langword="private"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Private(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsPrivate);

  /// <summary>
  ///   <para>Expects that a given object field is of <see langword="protected"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Protected(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsFamily);

  /// <summary>
  ///   <para>Expects that a given object field is of <see langword="public"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Public(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsPublic);

  /// <summary>
  ///   <para>Expects that a given object field is of <see langword="internal"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Internal(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsAssembly);

  /// <summary>
  ///   <para>Expects that a given object field is of <see langword="protected internal"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> ProtectedInternal(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsFamilyOrAssembly);

  /// <summary>
  ///   <para>Expects that a given object field is <see langword="static"/>.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Static(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsStatic);

  /// <summary>
  ///   <para>Expects that a given object field has a specified value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="subject">Target object.</param>
  /// <param name="value">Expected field value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Value(this IExpectation<FieldInfo> expectation, object subject, object value) => expectation.HaveSubject().And().Expected(field => Equals(field.GetValue(subject), value));
}