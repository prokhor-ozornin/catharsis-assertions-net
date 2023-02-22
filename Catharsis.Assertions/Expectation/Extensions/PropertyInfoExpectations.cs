using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="PropertyInfo"/> type.</para>
/// </summary>
/// <seealso cref="PropertyInfo"/>
public static class PropertyInfoExpectations
{
  /// <summary>
  ///   <para>Expects that a given object property can be read.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Writable(IExpectation{PropertyInfo})"/>
  public static IExpectation<PropertyInfo> Readable(this IExpectation<PropertyInfo> expectation) => expectation.HaveSubject().And().Expected(property => property.CanRead);

  /// <summary>
  ///   <para>Expects that a given object property is read-only (cannot be written to).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="WriteOnly(IExpectation{PropertyInfo})"/>
  public static IExpectation<PropertyInfo> ReadOnly(this IExpectation<PropertyInfo> expectation) => expectation.HaveSubject().And().Expected(property => property.CanRead && !property.CanWrite);

  /// <summary>
  ///   <para>Expects that a given object property can be written to.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Readable(IExpectation{PropertyInfo})"/>
  public static IExpectation<PropertyInfo> Writable(this IExpectation<PropertyInfo> expectation) => expectation.HaveSubject().And().Expected(property => property.CanWrite);

  /// <summary>
  ///   <para>Expects that a given object property is write-only (cannot be read).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <see cref="ReadOnly(IExpectation{PropertyInfo})"/>
  public static IExpectation<PropertyInfo> WriteOnly(this IExpectation<PropertyInfo> expectation) => expectation.HaveSubject().And().Expected(property => property.CanWrite && !property.CanRead);

  /// <summary>
  ///   <para>Expects that a given object property has a specified value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="subject">Target object.</param>
  /// <param name="value">Property value to check for.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<PropertyInfo> Value(this IExpectation<PropertyInfo> expectation, object subject, object value) => expectation.HaveSubject().And().Expected(property => Equals(property.GetValue(subject), value));
}