using OperatorOverload;

var counter = new Counter();

if(!counter) Console.WriteLine("false");
Console.WriteLine(counter);


void F(ref Counter counter) => counter++;

F(ref counter);

Console.WriteLine(counter);

Tuple<int, int> tuple = new Tuple<int, int>(9, 9);

counter = (Counter)tuple;
Console.WriteLine(++counter);

tuple = (Tuple<int, int>)counter;

Console.WriteLine(tuple);

Console.WriteLine(counter is ValueType);

int i = (int)counter;
Console.WriteLine(i is ValueType);
Console.WriteLine(i);

Console.ReadLine();