using System;

namespace MC.SHARE
{
    public static class Validate
    {
        public static void AgainstNull<T>(T value)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
        }

        public static void AgainstNull<T>(T value, string paramName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void AgainstNull<T>(T value, string paramName, string message)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        public static void AgainstNull<T>(T? value)
            where T : struct
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException();
            }
        }

        public static void AgainstNull<T>(T? value, string paramName)
            where T : struct
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void AgainstNull<T>(T? value, string paramName, string message)
            where T : struct
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        public static void AgainstNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
        }

        public static void AgainstNullOrEmpty(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void AgainstNullOrEmpty(string value, string paramName, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        public static void GreaterThan<T>(T lowerLimit, T value)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static void GreaterThan<T>(T lowerLimit, T value, string paramName)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        public static void GreaterThan<T>(T lowerLimit, T value, string paramName, string message)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        public static void LessThan<T>(T upperLimit, T value)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static void LessThan<T>(T upperLimit, T value, string paramName)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        public static void LessThan<T>(T upperLimit, T value, string paramName, string message)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        public static void IsTrue<T>(Func<T, bool> condition, T target)
        {
            if (!condition(target))
            {
                throw new ArgumentException("condition was not true");
            }
        }

        public static void IsTrue<T>(Func<T, bool> condition, T target, string paramName)
        {
            if (!condition(target))
            {
                throw new ArgumentException("condition was not true", paramName);
            }
        }

        public static void IsTrue<T>(Func<T, bool> condition, T target, string paramName, string message)
        {
            if (!condition(target))
            {
                throw new ArgumentException(message, paramName);
            }
        }

        public static T IsTypeOf<T>(object obj)
        {
            AgainstNull(obj);

            return obj is T reference
                ? reference
                : throw new ArgumentException($"{obj.GetType().Name} is not an instance of type {typeof(T).Name}");
        }
    }
}
