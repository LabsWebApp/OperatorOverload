using System;
using System.Data.SqlTypes;

namespace OperatorOverload;

internal class Counter
{
    protected bool Equals(Counter other) => 
        Value1 == other.Value1 && Value2 == other.Value2;

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Counter)obj);
    }

    public override int GetHashCode() => HashCode.Combine(Value1, Value2);

    public int Value1 { get; set; }
    public int Value2 { get; set; }

    public static bool operator ==(Counter a, Counter b) => 
        a.Value1 == b.Value1 && a.Value2 == b.Value2;

    public static bool operator !=(Counter a, Counter b) => !(a == b);

    public static bool operator >(Counter a, Counter b)
    {
        if(a.Value1 > b.Value1) return true;
        if(a.Value1 < b.Value1) return false;
        if(a.Value2 == b.Value2) return false;
        return a.Value2 > b.Value2;
    }

    public static bool operator <(Counter a, Counter b)
    {
        if (a.Value1 < b.Value1) return true;
        if (a.Value1 > b.Value1) return false;
        if (a.Value2 == b.Value2) return false;
        return a.Value2 < b.Value2;
    }

    public static Counter operator +(Counter a, Counter b)
        => new()
        {
            Value1 = a.Value1 + b.Value1,
            Value2 = a.Value2 + b.Value2
        };

    public static Counter operator -(Counter a, Counter b)
        => new()
        {
            Value1 = a.Value1 - b.Value1,
            Value2 = a.Value2 - b.Value2
        };

    public static bool operator true(Counter a) => a.Value1 != 0 || a.Value2 != 0;

    public static bool operator false(Counter a) => !a;

    public static bool operator !(Counter a) => a is { Value1: 0, Value2: 0 };

    public static Counter operator ++(Counter a) => new()
    {
        Value1 = a.Value1 + 1,
        Value2 = a.Value2 + 1
    };

    public static Counter operator --(Counter a) => new()
    {
        Value1 = a.Value1 - 1,
        Value2 = a.Value2 - 1
    };

    public override string ToString() => $"Value1 = {Value1}; Value2 = {Value2}";

    public static implicit operator Counter(Tuple<int, int> tuple) =>
        new()
        {
            Value1 = tuple.Item1,
            Value2 = tuple.Item2
        };

    public static explicit operator Tuple<int, int>(Counter counter) =>
        new Tuple<int, int>(counter.Value1, counter.Value2);

    public static explicit operator int(Counter counter) => counter.Value1;
}