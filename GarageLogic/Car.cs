using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {




        private eColor r_Color;
        private  eNumberOfDoors r_NumberOfDoors;

        public Car(string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels) :
             base(i_LicenseNumber, i_Engine, i_Wheels)
        {
            //r_Color = i_Color;
            //r_NumberOfDoors = i_NumberOfDoors;
        }
          public override string ToString()
          {
               return string.Format(@"{1}{0}
                                   Color:{2}{0}
                                   Number of doors{3}",
                                   Environment.NewLine, base.ToString(), r_Color, r_NumberOfDoors);
          }
        //public Car(string i_ModelName, string i_LicenseNumber, eColor i_Color,
        //    eNumberOfDoors i_NumberOfDoors, Engine i_Engine, List<Wheel> i_Wheels) :
        //     base(i_ModelName, i_LicenseNumber, i_Engine, i_Wheels)
        //{
        //    r_Color = i_Color;
        //    r_NumberOfDoors = i_NumberOfDoors;
        //}

        public eNumberOfDoors NumOfDoors
        {
            get { return r_NumberOfDoors; }
        }

        public eColor Color
        {
            get { return r_Color; }
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

        public int NumOfWheels
        {
            get { return base.r_CollectionOfWheels.Count;  }
        }

        public float MaxWheelsPressure
        {
            get { return base.r_CollectionOfWheels[0].AirPressure; }
        }

        public float MaxEnergy
        {
            get { return base.Engine.MaxEnergyUnit; }
        }

        //public int MaxFuelCapacity
        //{
        //    get { return k_MaxFuelCapacity; }
        //}

        public Engine engine
        {
            get { return r_Engine; }
        }

    }
}
