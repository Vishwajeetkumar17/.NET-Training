using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GarbageCollector
{
    /// <summary>
    /// Represents a container for a collection of names that supports resource management.
    /// </summary>
    /// <remarks>The BigBoy class provides a property to store a list of names and implements IDisposable to
    /// allow for explicit resource cleanup. After calling Dispose, the Names property is set to null and should not be
    /// accessed.</remarks>
    public class BigBoy : IDisposable
    {
        public ArrayList Names {  get; set; }

        public BigBoy() { }

        public void Dispose()
        {
            Names = null;
        }
    }
}
