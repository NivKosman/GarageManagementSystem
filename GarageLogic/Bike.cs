using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Bike: Vehicle
    {
        private readonly eBikeLicenseType r_LicenseType;
        private readonly int r_EngineSize;

          public override string ToString()
          {
               return string.Format(@"{1}{0}
                                   Bike License Type:{2}{0}
                                   Energy Size:{3}",
                                   Environment.NewLine, base.ToString(), r_LicenseType, r_EngineSize);
          }
        public Bike(string i_ModelName, string i_LicenseNumber, int i_EngineSize,
             eBikeLicenseType i_LicenseType, Engine i_Engine, List<Wheel> i_Wheels) :
             base(i_ModelName, i_LicenseNumber, i_Engine, i_Wheels)
        {
            r_LicenseType = i_LicenseType;
            r_EngineSize = i_EngineSize;
        }

    }
}
