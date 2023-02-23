﻿namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="Lazy{T}"/> type.</para>
/// </summary>
/// <seealso cref="Lazy{T}"/>
public static class LazyProtections
{
  /// <summary>
  ///   <para>Protects given lazily instantiated object from either being <see langword="null"/> or having no value.</para>
  /// </summary>
  /// <typeparam name="T">Type of lazily instantiated instance.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="instance">Object to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static Lazy<T> Null<T>(this IProtection protection, Lazy<T> instance, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (instance is null || !instance.IsValueCreated || instance.Value is null)
    {
      throw new ArgumentNullException(error);
    }
    
    return instance;
  }
}