﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace XtremeModpackLazyness
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			System.Console.WriteLine("Starting XML");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
