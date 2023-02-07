﻿using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="FieldInfo"/>
public static class FieldInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Type{T}(IExpectation{FieldInfo})"/>
  public static IExpectation<FieldInfo> Type(this IExpectation<FieldInfo> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(field => field.FieldType == type);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Type(IExpectation{FieldInfo}, System.Type)"/>
  public static IExpectation<FieldInfo> Type<T>(this IExpectation<FieldInfo> expectation) => expectation.Type(typeof(T));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FieldInfo> Private(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsPrivate);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FieldInfo> Protected(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsFamily);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FieldInfo> Public(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsPublic);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<FieldInfo> Internal(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsAssembly);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<FieldInfo> ProtectedInternal(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsFamilyOrAssembly);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FieldInfo> Static(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expected(field => field.IsStatic);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="subject"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<FieldInfo> Value(this IExpectation<FieldInfo> expectation, object subject, object value) => expectation.HaveSubject().And().Expected(field => Equals(field.GetValue(subject), value));
}