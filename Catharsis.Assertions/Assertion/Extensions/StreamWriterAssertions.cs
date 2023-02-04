﻿using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="StreamWriter"/>
public static class StreamWriterAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="writer"></param>
  /// <param name="encoding"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Encoding(this IAssertion assertion, StreamWriter writer, Encoding encoding, string message = null) => writer is not null ? assertion.Equal(writer.Encoding, encoding, message) : throw new ArgumentNullException(nameof(writer));
}