﻿using System.Collections.Specialized;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
/// <seealso cref="NameValueCollection"/>
public static class CollectionsAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="collection"></param>
  /// <param name="count"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Count(IAssertion, NameValueCollection, int, string)"/>
  public static IAssertion Count<T>(this IAssertion assertion, ICollection<T> collection, int count, string message = null) => collection is not null ? assertion.True(collection.Count == count, message) : throw new ArgumentNullException(nameof(collection));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="collection"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Empty(IAssertion, NameValueCollection, string)"/>
  public static IAssertion Empty<T>(this IAssertion assertion, ICollection<T> collection, string message = null) => assertion.Count(collection, 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="collection"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion ReadOnly<T>(this IAssertion assertion, ICollection<T> collection, string message = null) => collection is not null ? assertion.True(collection.IsReadOnly, message) : throw new ArgumentNullException(nameof(collection));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="collection"></param>
  /// <param name="count"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Count{T}(IAssertion, ICollection{T}, int, string)"/>
  public static IAssertion Count(this IAssertion assertion, NameValueCollection collection, int count, string message = null) => collection is not null ? assertion.True(collection.Count == count, message) : throw new ArgumentNullException(nameof(collection));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="collection"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Empty{T}(IAssertion, ICollection{T}, string)"/>
  public static IAssertion Empty(this IAssertion assertion, NameValueCollection collection, string message = null) => assertion.Count(collection, 0, message);
}