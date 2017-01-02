using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using AtomicEngine;


namespace AtomicPlayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Capture all metrics, including engine subsystems, etc
            // Application.SetAutoMetrics(true);

            Application.Run<AtomicMain>(args);
        }
    }
}
