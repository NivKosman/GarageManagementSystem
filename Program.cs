﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
     class Program
     {
          static void Main()
          {
            IOhandler io = new IOhandler();

            io.AddNewVehicle();
            io.ShowAllLicenseNumberVehicle();
          }
     }
}
