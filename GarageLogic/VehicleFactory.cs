using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class VehicleFactory
    {
        private const int k_CarNumberOfWheels = 4;
        private const float k_CarMaxPressure = 31;
        private const int k_CarMaxElectricEngTime = 108; //1.8 * 60
        private const int k_CarMaxFuelCapacity = 55;
        private const eFuelType k_CarFuelType = eFuelType.Octan96;
        //private MakeCreateNewCarRequest m_Request;

        public Vehicle CreateNewCarOfType(eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            Vehicle vehicle;
            Engine engine;
            List<Wheel> wheels;
            switch (i_VehicleType)
            {
                case (eVehicleType.FuelCar):
                    wheels = CreateWheels(k_CarMaxPressure, k_CarNumberOfWheels);
                    engine = new FuelEngine(k_CarMaxFuelCapacity, k_CarFuelType);
                    vehicle = new Car(i_LicenseNumber, engine, wheels);
                    break;
                case (eVehicleType.ElectricCar):
                    wheels = CreateWheels(k_CarMaxPressure, k_CarNumberOfWheels);
                    engine = new ElectricEngine(k_CarMaxElectricEngTime);
                    vehicle = new Car(i_LicenseNumber, engine, wheels);
                    break;
                default:
                    throw new ArgumentException(string.Format("Error: Invalid vehicle type {0}", i_VehicleType));
            }

            return vehicle;
        }
        public List<Wheel> CreateWheels(float i_MaxPressure, int i_NumOfWheels)
        {
            List<Wheel> wheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                wheels[i] = new Wheel(i_MaxPressure);
            }

            return wheels;
        }
       
        //private ElectricEngine CreateElectricEngineForCar()
        //{
        //    ElectricEngine engine;
        //    engine = new ElectricEngine(m_Request.Request.HoursLeft, (float)1.8);
        //    return engine;
        //}

        //private ElectricEngine CreateElectricEngineForBike()
        //{
        //    ElectricEngine engine;
        //    engine = new ElectricEngine(m_Request.Request.HoursLeft, (float)1.4);
        //    return engine;
        //}

        //private FuelEngine CreateFuelEngineForCar()
        //{
        //    FuelEngine engine;
        //    engine = new FuelEngine(m_Request.Request.CurrentFuelCapacity, 55, eFuelType.Octan96);
        //    return engine;
        //}

        //private FuelEngine CreateFuelEngineForBike()
        //{
        //    FuelEngine engine;
        //    engine = new FuelEngine(m_Request.Request.CurrentFuelCapacity, 8, eFuelType.Octan95);
        //    return engine;
        //}

        //private FuelEngine CreateFuelEngineForTruck()
        //{
        //    FuelEngine engine;
        //    engine = new FuelEngine(m_Request.Request.CurrentFuelCapacity, 110, eFuelType.Soler);
        //    return engine;
        //}




    }
}
