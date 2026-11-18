using System;
using System.Collections.Generic;
using System.Linq;

public class ObjectResolver
{
    private readonly Dictionary<Type, Type> _registrations = new();
    private readonly Dictionary<Type, object> _instances = new();
    private readonly HashSet<Type> _resolving = new(); // circular dependency detection

    public void RegisterInstance<T>(T instance) => _instances[typeof(T)] = instance;

    public void Register<TService, TImpl>() where TImpl : TService
        => _registrations[typeof(TService)] = typeof(TImpl);

    public void Register<T>() => Register<T, T>();

    public T Resolve<T>() => (T)Resolve(typeof(T));

    private object Resolve(Type type)
    {
        if (_instances.TryGetValue(type, out var existing))
            return existing;

        if (!_registrations.TryGetValue(type, out var implType))
            throw new InvalidOperationException($"Type {type.Name} is not registered.");

        if (!_resolving.Add(type))
            throw new InvalidOperationException($"Circular dependency detected on {type.Name}.");

        try
        {
            var ctor = implType.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .First();

            var args = ctor.GetParameters()
                .Select(p => Resolve(p.ParameterType)) // resolve, don't pass the Type
                .ToArray();

            var instance = ctor.Invoke(args);
            _instances[type] = instance; // singleton
            return instance;
        }
        finally
        {
            _resolving.Remove(type);
        }
    }
}