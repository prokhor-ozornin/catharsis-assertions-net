namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="Type"/> type.</para>
/// </summary>
/// <seealso cref="Type"/>
public static class TypeAssertions
{
  /// <summary>
  ///   <para>Asserts that a given type is declared <see langword="abstract"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="type">Type to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Abstract(this IAssertion assertion, Type type, string error = null) => type is not null ? assertion.True(type.IsAbstract && !type.IsSealed, error) : throw new ArgumentNullException(nameof(type));

  /// <summary>
  ///   <para>Asserts that a given type is declared <see langword="sealed"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="type">Type to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Sealed(this IAssertion assertion, Type type, string error = null) => type is not null ? assertion.True(type.IsSealed && !type.IsAbstract, error) : throw new ArgumentNullException(nameof(type));

  /// <summary>
  ///   <para>Asserts that a given type is declared <see langword="static"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="type">Type to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Static(this IAssertion assertion, Type type, string error = null) => type is not null ? assertion.True(type.IsAbstract && type.IsSealed, error) : throw new ArgumentNullException(nameof(type));

  /// <summary>
  ///   <para>Asserts that a given type is of <see langword="public"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="type">Type to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Public(this IAssertion assertion, Type type, string error = null) => type is not null ? assertion.True(type.IsPublic && type.IsVisible, error) : throw new ArgumentNullException(nameof(type));

  /// <summary>
  ///   <para>Asserts that a given type is of <see langword="internal"/> visibility.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="type">Type to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Internal(this IAssertion assertion, Type type, string error = null) => type is not null ? assertion.True(type.IsNotPublic && !type.IsVisible, error) : throw new ArgumentNullException(nameof(type));

  /// <summary>
  ///   <para>Asserts that a given type is derived from a specified type.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="subclass">Asserted subclass type.</param>
  /// <param name="superclass">Asserted superclass type.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="subclass"/>, or <paramref name="superclass"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Subclass(this IAssertion assertion, Type subclass, Type superclass, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (subclass is null) throw new ArgumentNullException(nameof(subclass));
    if (superclass is null) throw new ArgumentNullException(nameof(superclass));

    return assertion.True(subclass.IsSubclassOf(superclass), error);
  }

  /// <summary>
  ///   <para>Asserts that a given type is derived from a specified type.</para>
  /// </summary>
  /// <typeparam name="T">Asserted superclass type.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="subclass">Asserted subclass type.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="subclass"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Subclass<T>(this IAssertion assertion, Type subclass, string error = null) => assertion.Subclass(subclass, typeof(T), error);

  /// <summary>
  ///   <para>Asserts that an instance of the given type is assignable from an instance of the specified type.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="to">Asserted assignable type.</param>
  /// <param name="from">Asserted assigned type.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="to"/>, or <paramref name="from"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="AssignableFrom{T}(IAssertion, Type, string)"/>
  public static IAssertion AssignableFrom(this IAssertion assertion, Type to, Type from, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (to is null) throw new ArgumentNullException(nameof(to));
    if (from is null) throw new ArgumentNullException(nameof(from));
    
    return assertion.True(to.IsAssignableFrom(from), error);
  }

  /// <summary>
  ///   <para>Asserts that an instance of the given type is assignable from an instance of the specified type.</para>
  /// </summary>
  /// <typeparam name="T">Asserted assigned type.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="from">Asserted assignable type.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="from"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="AssignableFrom(IAssertion, Type, Type, string)"/>
  public static IAssertion AssignableFrom<T>(this IAssertion assertion, Type from, string error = null) => assertion.AssignableFrom(from, typeof(T), error);

#if NET7_0_OR_GREATER
  /// <summary>
  ///   <para>Asserts that an instance of the given type is assignable to an instance of the specified type.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="from">Asserted assignable type.</param>
  /// <param name="to">Asserted assigned type.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="from"/>, or <paramref name="to"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="AssignableTo{T}(IAssertion, Type, string)"/>
  public static IAssertion AssignableTo(this IAssertion assertion, Type from, Type to, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (from is null) throw new ArgumentNullException(nameof(from));
    if (to is null) throw new ArgumentNullException(nameof(to));

    return assertion.True(from.IsAssignableTo(to), error);
  }

  /// <summary>
  ///   <para>Asserts that an instance of the given type is assignable to an instance of the specified type.</para>
  /// </summary>
  /// <typeparam name="T">Asserted assigned type.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="to">Type to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="to"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="AssignableTo(IAssertion, Type, Type, string)"/>
  public static IAssertion AssignableTo<T>(this IAssertion assertion, Type to, string error = null) => assertion.AssignableTo(to, typeof(T), error);
  #endif
}