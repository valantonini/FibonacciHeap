using System;
public class HeapEmptyException : Exception
{
    public HeapEmptyException() : base() { }
    public HeapEmptyException(string msg) : base(msg) { }

}