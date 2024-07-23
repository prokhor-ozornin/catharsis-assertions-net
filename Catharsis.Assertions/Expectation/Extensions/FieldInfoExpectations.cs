using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="FieldInfo"/> type.</para>
/// </summary>
/// <seealso cref="FieldInfo"/>
public static class FieldInfoExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="FieldInfo"/> is of the specified <see cref="Type"/>.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="type">Type of field to check.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="type"/> is <see langword="null"/>.</exception>
  /// <seealso cref="Type{T}(IExpectation{FieldInfo})"/>
  public static IExpectation<FieldInfo> Type(this IExpectation<FieldInfo> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(field => field.FieldType == type);

  /// <summary>
  ///   <para>Expects that the given <see cref="FieldInfo"/> is of the specified <see cref="Type"/>.</para>
  /// </summary>
  /// <typeparam name="T">Type of field to check.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  /// <seealso cref="Type(IExpectation{FieldInfo}, System.Type)"/>
  public static IExpectation<FieldInfo> Type<T>(this IExpectation<FieldInfo> expectation) => expectation.Type(typeof(T));

  /// <summary>
  ///   <para>Expects that the given <see cref="FieldInfo"/> has <see langword="private"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Private(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsPrivate);

  /// <summary>
  ///   <para>Expects that the given <see cref="FieldInfo"/> has <see langword="protected"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Protected(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsFamily);

  /// <summary>
  ///   <para>Expects that the given <see cref="FieldInfo"/> has <see langword="public"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Public(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsPublic);

  /// <summary>
  ///   <para>Expects that the given <see cref="FieldInfo"/> has <see langword="internal"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Internal(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsAssembly);

  /// <summary>
  ///   <para>Expects that the given <see cref="FieldInfo"/> has <see langword="protected internal"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> ProtectedInternal(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsFamilyOrAssembly);

  /// <summary>
  ///   <para>Expects that the given <see cref="FieldInfo"/> is <see langword="static"/>.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Static(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsStatic);

  /// <summary>
  ///   <para>Expects that the given object has a specified field value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="subject">Target object.</param>
  /// <param name="value">Expected field's value.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<FieldInfo> Value(this IExpectation<FieldInfo> expectation, object subject, object value) => expectation.HaveSubject().And().Expected(field => Equals(field.GetValue(subject), value));
}