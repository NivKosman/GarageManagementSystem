using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_IsHoldsDangerCargo;
        private float m_CargoCapacity;

        public override string ToString()
          {
               return string.Format(@"{1}{0}
                                   Holds Danager Cargo:{2}{0}
                                   Cargo capacity:{3}",
                                   Environment.NewLine, base.ToString(), m_IsHoldsDangerCargo, m_CargoCapacity);
          }

        public Truck(string i_LicenseNumber, Engine i_Engine,
              List<Wheel> i_Wheels) :
             base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }

        public float CargoCapacity
        {
            get { return m_CargoCapacity; } 
        }

    }
}
