﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FuelEngine : Engine
    {

        private eFuelType r_FuelType;

        public FuelEngine(float i_MaxFuelCapacity, eFuelType i_FuelType) :
         base(i_MaxFuelCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public void Fill(float i_AmoutOfLiters, eFuelType i_FuelType)
        {
            if (r_FuelType == i_FuelType)
            {
                base.Fill(i_AmoutOfLiters);
            }
            else
            {
                throw new ArgumentException(string.Format(@"Error: Incorrect Fuel entered, correct fuel type is {0}
                                                            ", r_FuelType));
            }
        }

          public override string ToString()
          {
               return string.Format(@"Fuel engine
FuelType:{0}
Current amout of liters:{1}
Maximum amout of liters:{2}", r_FuelType, m_EnergyUnitLeft, m_MaxEnergyUnit);
                                  
          }

          public eFuelType FuelType
        {
            set
            {
                if (Enum.IsDefined(typeof(eFuelType), value))
                {
                    r_FuelType = value;
                }
                else
                {
                    string errorMessage = string.Format("Error: Invalid Fuel type");
                    throw new ArgumentException(errorMessage);
                }
            }
            get { return r_FuelType; }

           
        }

        public float MaxFuelCapacity
        {
            get { return m_MaxEnergyUnit; }
        }

        public float CurrentFuelCapacity
        {
            set{ base.Energy = value; }
            get { return base.Energy; }
        }

    }
}
