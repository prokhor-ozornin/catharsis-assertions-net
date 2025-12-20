using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="Assembly"/> type.</para>
/// </summary>
/// <seealso cref="Assembly"/>
public static class AssemblyExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<Assembly> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="Assembly"/> defines a specified <see cref="Type"/>.</para>
    /// </summary>
    /// <param name="type">Expected type.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="type"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Define{T}(IExpectation{Assembly})"/>
    public IExpectation<Assembly> Define(Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(assembly => assembly.DefinedTypes.Contains(type));

    /// <summary>
    ///   <para>Expects that the given <see cref="Assembly"/> defines a specified <see cref="Type"/>.</para>
    /// </summary>
    /// <typeparam name="T">Expected type.</typeparam>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    /// <seealso cref="Define(IExpectation{Assembly}, Type)"/>
    public IExpectation<Assembly> Define<T>() => expectation.Define(typeof(T));

    /// <summary>
    ///   <para>Expects that the given <see cref="Assembly"/> was dynamically generated in the current process using reflection.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Assembly> Dynamic() => expectation.HaveSubject().And().Expected(assembly => assembly.IsDynamic);
  }
}