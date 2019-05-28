using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {

        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels) :
             base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }
        public override string ToString()
        {
            return string.Format(@"{1}{0}
                                   Color:{2}{0}
                                   Number of doors{3}",
                                Environment.NewLine, base.ToString(), m_Color, m_NumberOfDoors);
        }

        public eNumberOfDoors NumOfDoors
        {
            get { return m_NumberOfDoors; }
        }

        public eColor Color
        {
            get { return m_Color; }
        }

        public eFuelType FuelType
        {
            get
            {
                if (r_Engine is FuelEngine)
                {
                    return ((FuelEngine)r_Engine).FuelType;
                }
                else
                {
                    throw new InvalidCastException("Error: Car is not using Fuel Engine");
                }

            }
        }

        public float MaxEnergy
        {
            get { return base.Engine.MaxEnergyUnit; }
        }

        public Engine engine
        {
            get { return r_Engine; }
        }

    }
}
