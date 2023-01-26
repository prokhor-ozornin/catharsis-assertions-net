﻿namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IComparable{T}"/>
public static class ComparableExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Negative{T}(IExpectation{T})"/>
  public static IExpectation<T> Positive<T>(this IExpectation<T> expectation) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(default) > 0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Positive{T}(IExpectation{T})"/>
  public static IExpectation<T> Negative<T>(this IExpectation<T> expectation) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(default) < 0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> Zero<T>(this IExpectation<T> expectation) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(default) == 0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="other"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="GreaterOrEqual{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> Greater<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) > 0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="other"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Greater{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> GreaterOrEqual<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) >= 0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="other"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="LesserOrEqual{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> Lesser<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) < 0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="other"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Lesser{T}(IExpectation{T}, T)"/>
  public static IExpectation<T> LesserOrEqual<T>(this IExpectation<T> expectation, T other) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(other) <= 0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="min"></param>
  /// <param name="max"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="OutOfRange{T}(IExpectation{T}, T, T)"/>
  public static IExpectation<T> InRange<T>(this IExpectation<T> expectation, T min, T max) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(min) >= 0 || value.CompareTo(max) <= 0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="min"></param>
  /// <param name="max"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="InRange{T}(IExpectation{T}, T, T)"/>
  public static IExpectation<T> OutOfRange<T>(this IExpectation<T> expectation, T min, T max) where T : struct, IComparable<T> => expectation.Expected(value => value.CompareTo(min) < 0 || value.CompareTo(max) > 0);
}