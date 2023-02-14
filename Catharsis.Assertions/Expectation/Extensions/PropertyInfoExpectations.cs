﻿using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="PropertyInfo"/>
public static class PropertyInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Writable(IExpectation{PropertyInfo})"/>
  public static IExpectation<PropertyInfo> Readable(this IExpectation<PropertyInfo> expectation) => expectation.HaveSubject().And().Expected(property => property.CanRead);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="WriteOnly(IExpectation{PropertyInfo})"/>
  public static IExpectation<PropertyInfo> ReadOnly(this IExpectation<PropertyInfo> expectation) => expectation.HaveSubject().And().Expected(property => property.CanRead && !property.CanWrite);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Readable(IExpectation{PropertyInfo})"/>
  public static IExpectation<PropertyInfo> Writable(this IExpectation<PropertyInfo> expectation) => expectation.HaveSubject().And().Expected(property => property.CanWrite);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <see cref="ReadOnly(IExpectation{PropertyInfo})"/>
  public static IExpectation<PropertyInfo> WriteOnly(this IExpectation<PropertyInfo> expectation) => expectation.HaveSubject().And().Expected(property => property.CanWrite && !property.CanRead);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="subject"></param>
  /// <param name="value"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<PropertyInfo> Value(this IExpectation<PropertyInfo> expectation, object subject, object value) => expectation.HaveSubject().And().Expected(property => Equals(property.GetValue(subject), value));
}