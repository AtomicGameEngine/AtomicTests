using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using AtomicEngine;


namespace AtomicPlayer
{
    public class Program
    {
        static Type makeSureAssemblyIsLoaded;

        public static void Main(string[] args)
        {
            makeSureAssemblyIsLoaded = typeof(ExternalDll.ExternalDllComponent);
            Application.Run<AtomicMain>(args);
        }
    }
}
