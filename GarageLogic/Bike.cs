using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Bike: Vehicle
    {
        private eBikeLicenseType m_LicenseType;
        private int m_EngineSize;
        private string m_ModelName;

          public override string ToString()
          {
               return string.Format(@"{1}{0}
                                   Bike License Type:{2}{0}
                                   Energy Size:{3}",
                                   Environment.NewLine, base.ToString(), m_LicenseType, m_EngineSize);
          }
        public Bike(string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels) :
             base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }

    }
}
