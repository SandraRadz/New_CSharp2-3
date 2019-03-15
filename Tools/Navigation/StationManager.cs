using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation
{
    class StationManager
    {

        internal static Person CurrentUser { get; set; }


        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
