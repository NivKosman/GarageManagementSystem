using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool v_IsHoldsDangerCargo;
        private float m_CargoCapacity;
        public const int k_NumberOfWheels = 12;

        public override string ToString()
          {
               return string.Format(@"{1}{0}
                                   Holds Danager Cargo:{2}{0}
                                   Cargo capacity:{3}",
                                   Environment.NewLine, base().ToString, v_IsHoldsDangerCargo, m_CargoCapacity);
          }

        public Truck(string i_ModelName, string i_LicenseNumber, Engine i_Engine,
             bool i_IsHoldsDangerCargo, float i_CargoCapicity, List<Wheel> i_Wheels) :
             base(i_ModelName, i_LicenseNumber, i_Engine, i_Wheels)
        {
            v_IsHoldsDangerCargo = i_IsHoldsDangerCargo;
            m_CargoCapacity = i_CargoCapicity;
        }

        public float CargoCapacity
        {
            get { return m_CargoCapacity; } 
        }

        public static int NumOfWheels
        {
            get { return k_NumberOfWheels; }
        }
    }
}
