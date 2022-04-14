using System;

/// <summary>
/// A generic singleton class that returns the instance value
/// </summary>
/// <typeparam name="T"></typeparam>
[System.Serializable]
public class Singleton<T> where T : class, new()
{
    // Protected constructor
    protected Singleton()
    {
    }

    // Set instance
    private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

    // Return instance
    public static T Instance => instance.Value;
}