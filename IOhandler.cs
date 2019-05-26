using System;
using System.Collections.Generic;
//using System.Linq;
using System.Reflection;
using System.Text;
//using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class IOhandler
    {
        InputValidator m_Validator;
        UI m_UI;
        GarageLogic.Garage m_Garage;

        public IOhandler()
        {
            m_Validator = new InputValidator();
            m_UI = new UI();
            m_Garage = new GarageLogic.Garage();
        }

        public void RunSelectedOption(int i_Selection)
        {
            switch (i_Selection)
            {
                case (1):
                         AddNewVehicle();
                         break;
                case (2):
                         ShowLicenseNumberVehicle();
                         break;
                case (3):
                         ChangeStatusOfVehicle();
                         break;
                case (4):
                         FillWheelsToMaximum();
                         break;
                case (5):
                         FillFuelVehicle();
                         break;
                case (6):
                         FillElectricVehicle();
                         break;
                case (7):
                         ShowFullDetailsOfVehcile();
                         break;
                default:
                    string errMsg = string.Format("Error: Invalid option was entered: {0}", i_Selection);
                    throw new FormatException(errMsg);
            }
        }
          
          public void ShowLicenseNumberVehicle()
          {
               m_UI.PrintMessage(Messages.AskingAllOrByStatus);
               int statusNumber;
               string statusNumberString = m_UI.GetInput();

               if (!m_Validator.CheckIfInputIsNumber(statusNumberString, out statusNumber))
               {
                    throw new FormatException(Messages.FormatMessages);
               }
               else
               {
                    if (!m_Validator.CheckIfNumberInRangeOfNewStatus(ref statusNumber))
                    {
                         ShowAllLicenseNumberVehicle();
                    }
                    else
                    {
                         ShowLicenseNumberByStatus((eVehicleStatus)statusNumber);
                    }
               }
          }

          public void ShowAllLicenseNumberVehicle()
          {
               StringBuilder sb = new StringBuilder();
               // sb=m_Garage.AllLicenseNumber();
               m_UI.PrintMessage(sb.ToString());
          }

          public void ShowLicenseNumberByStatus(eVehicleStatus i_Status)
          {
               StringBuilder sb = new StringBuilder();
               // sb=m_GarageAllLicenseNumbersByStatus(eVehicleStatus i_Status)
               m_UI.PrintMessage(sb.ToString());
          }
          public void ChangeStatusOfVehicle()
          {
               m_UI.AskingLicenseNumber();
               string licenseNumber = m_UI.GetInput();
               m_Validator.ValidateLicenseNumber(licenseNumber);
               int statusNumber;
               m_UI.AskingNewStatusOfVehicle();
               string statusNumberString = m_UI.GetInput();

               if (!m_Validator.CheckIfInputIsNumber(statusNumberString, out statusNumber))
               {
                    throw new FormatException(Messages.FormatMessages);
               }
               else
               {
                    if (!m_Validator.CheckIfNumberInRangeOfNewStatus(ref statusNumber))
                    {
                         //ValueOutOfRangeExeption
                    }
                    else
                    {
                         //m_garage.UpdateVehicleStatus(licenseNumber,statusnumber)
                    }
               }
          }

          public void FillWheelsToMaximum()
          {
               m_UI.AskingLicenseNumber();
               string licenseNumber = m_UI.GetInput();
               m_Validator.ValidateLicenseNumber(licenseNumber);
               bool vehicleExist = m_Garage.VehicleExistInGarage(licenseNumber);

               if(vehicleExist)
               {
                    m_Garage.FillToMaximum(licenseNumber);
               }
               else
               {
                    string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                    throw new ArgumentException(errMsg);
               }
          }

          public void FillFuelVehicle()
          {
               float amountOfFuel;
               int typeOfFuel;
               m_UI.AskingLicenseNumber();
               string licenseNumber = m_UI.GetInput();
               m_Validator.ValidateLicenseNumber(licenseNumber);
               bool vehicleExist = m_Garage.VehicleExistInGarage(licenseNumber);

               if (vehicleExist)
               {
                    amountOfFuel = m_UI.GetFloatInput();
                    m_UI.PrintMessage(Messages.AskingTypeOfFuel);
                    typeOfFuel = m_UI.GetIntInRange(1, 4);
                    m_Garage.FillFuel(licenseNumber,amountOfFuel,(eFuelType)typeOfFuel);
               }
               else
               {
                    string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                    throw new ArgumentException(errMsg);
               }
          }

          public void FillElectricVehicle()
          {
               int amountOfMinutes;
               m_UI.AskingLicenseNumber();
               string licenseNumber = m_UI.GetInput();
               m_Validator.ValidateLicenseNumber(licenseNumber);
               bool vehicleExist = m_Garage.VehicleExistInGarage(licenseNumber);

               if (vehicleExist)
               {
                    amountOfMinutes = m_UI.GetIntNumber();
                    //m_Garage.FillElectric(licenseNumber,amountOfMinutes);
               }
               else
               {
                    string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                    throw new ArgumentException(errMsg);
               }
          }

          public void ShowFullDetailsOfVehcile()
          {
               m_UI.AskingLicenseNumber();
               string licenseNumber = m_UI.GetInput();
               m_Validator.ValidateLicenseNumber(licenseNumber);
               bool vehicleExist = m_Garage.VehicleExistInGarage(licenseNumber);

               if (vehicleExist)
               {
                    m_Garage.ShowFullDetailsByLicendeId(licenseNumber);
               }
               else
               {
                    string errMsg = string.Format("Vehicle {0} is not existing in the garage", licenseNumber);
                    throw new ArgumentException(errMsg);
               }
          }

        public void AddNewVehicle() 
        {
            m_UI.AskingLicenseNumber();
            string licenseNumber = m_UI.GetInput();
            bool vehicleExist = m_Garage.VehicleExistInGarage(licenseNumber);

            if (vehicleExist)
            {
                m_Garage.setInProgressStatus(licenseNumber);
                string errMsg = string.Format("Vehicle {0} is already in the Garage, status updated to InProgress..", licenseNumber);
                throw new ArgumentException(errMsg);
            }
            else
            {
                GarageLogic.eVehicleType vehicleType = GetVehicleType();
                GarageLogic.Record record = m_Garage.AddNewVehicle(licenseNumber, vehicleType);

            }

        }

        public void UpdateRecordWithRelevantInformation(GarageLogic.Record record)
        {

            string ownerName = getName();
            string phoneNumber = getPhoneNumber();
            record.Owner = ownerName;
            record.Phone = phoneNumber;

            updateVehicleWithAnyExtraFields(record.Vehicle);
        }

        public void updateVehicleWithAnyExtraFields(GarageLogic.Vehicle i_Vehicle)
        {
            FieldInfo[] vehicleMembers = i_Vehicle.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

            foreach (FieldInfo memberField in vehicleMembers)
            {
                //string nameOfMemberField = getNameOfMemberField(memberField);
                setValueOfMemberField(memberField, i_Vehicle);
                printOptionsForMemberField(memberField);
            }
        }

        private void setValueOfMemberField(FieldInfo i_memberField, GarageLogic.Vehicle i_Vehicle)
        {

            string nameOfMemberField = getNameOfMemberField(i_memberField);
            Type fieldType = i_memberField.GetType();
            string fieldOutName = string.Format("Enter the value for field - {0}:{1}", nameOfMemberField, Environment.NewLine);
            if (fieldType.IsEnum) // is number
            {
                System.Array enumValues = System.Enum.GetValues(fieldType); //get enum options

                m_UI.ShowOptionFromArray(fieldOutName, enumValues);

                int intValue = m_UI.GetIntNumber();
                PropertyInfo propertyInfo = i_Vehicle.GetType().GetProperty(i_memberField.Name);
                propertyInfo.SetValue(i_Vehicle, Convert.ChangeType(intValue, i_memberField.FieldType), null);
                //System.Type enumUnderlyingType = System.Enum.GetUnderlyingType(fieldType);

                //int minValue = enumValues.GetValue(0);
                //int maxValue = 
                //TODO: handle num range

                //int intValue = m_UI.GetIntNumber();//m_UI.GetIntInRange(minValue), enumValues.GetValue(enumValues.Length - 1);
                //i_memberField.SetValue(i_Vehicle, Enum.Parse(i_memberField.GetType(), intValue);
                //i_memberField.SetValue(i_Vehicle, Convert.ChangeType(intValue, i_memberField.FieldType), null);


                //setMemberValue<>(i_memberField, i_Vehicle, intValue);
                //IEnumerable<FieldInfo.GetFieldFromHandle(i_memberField)> enumOptions = //GarageLogic.eNumUtils.GetValues<T>();
                //GarageLogic.eVehicleType enumOptions = GetVehicleType<typeof(fieldType)>(Messages.SelectVehicleType);
                //    IEnumerable<T> enumOptions = GarageLogic.eNumUtils.GetValues<T>();
                //GetVehicleType<GarageLogic.eVehicleType>(Messages.SelectVehicleType)
                //
                //m_UI.PrintMessage(fieldOutName);

            }
            else if (fieldType == typeof(Boolean)) //is boolean
            {
                fieldOutName = string.Concat(fieldOutName, string.Format("(1 - True, 0 - False){0}",Environment.NewLine));
                m_UI.PrintMessage(fieldOutName);
                bool boolValue = m_UI.GetBool();
                setMemberValue<bool>(i_memberField, i_Vehicle, boolValue);
            }
            else if (fieldType == typeof(float))
            {
                m_UI.PrintMessage(fieldOutName);
                float floatValue = m_UI.GetFloatInput();
                setMemberValue<float>(i_memberField, i_Vehicle, floatValue);
            }
            else if (fieldType == typeof(int))
            {
                m_UI.PrintMessage(fieldOutName);
                int intValue = m_UI.GetIntNumber();
                setMemberValue<int>(i_memberField, i_Vehicle, intValue);
            }
            else
            {
                m_UI.PrintMessage(fieldOutName);
                string value = m_UI.GetInput();
                setMemberValue<string>(i_memberField, i_Vehicle, value);
            }




        }
        private void setMemberValue<T>(FieldInfo i_memberField, GarageLogic.Vehicle i_Vehicle, T i_Value)
        {
            i_memberField.SetValue(i_Vehicle, i_Value);
        }

        //T getValueForField<T>()
        //{
        //    T retVal;
             
        //}

        private void printOptionsForMemberField(FieldInfo memberField)
        {

        }

        private string getNameOfMemberField(FieldInfo i_MemberField)
        {
            return i_MemberField.Name; 
        }

        private string getName()
        {
            m_UI.PrintMessage(Messages.EnterOwnerName);
            string ownerName = m_UI.GetInput();

               try
               {
                    m_Validator.CheckIfStringIsValidOwnerName(ownerName);
               }
               catch(Exception ex)
               {
                    m_UI.PrintMessage(string.Format("Error: {0}", ex.Message));
               }
           
            return ownerName;
        }

        private string getPhoneNumber()
        {
            m_UI.PrintMessage(Messages.EnterPhoneNumber);
            string phoneNumber = m_UI.GetInput();

             try
               {
                    m_Validator.CheckIfStringIsValidPhoneNumber(phoneNumber);
               }
               catch(Exception ex)
               {
                    m_UI.PrintMessage(string.Format("Error: {0}", ex.Message));
               }

            return phoneNumber;
        }

        public GarageLogic.eVehicleType GetVehicleType()
        {
            GarageLogic.eVehicleType vehicleType;
            try
            {
                vehicleType = GetVehicleType<GarageLogic.eVehicleType>(Messages.SelectVehicleType);
            } 
            catch (Exception ex)
            {
                m_UI.PrintMessage(string.Format("Error: {0}", ex.Message));
                return GetVehicleType();
            }

            return vehicleType;
        }

        public T GetVehicleType<T>(string i_Message)
        {
            IEnumerable<T> enumOptions = GarageLogic.eNumUtils.GetValues<T>();
            m_UI.ShowOptions(i_Message, enumOptions);
            string selectedOption = m_UI.GetInput();
            int selectedNumber;
            int.TryParse(selectedOption, out selectedNumber);
            T selectEnum = (T)Enum.ToObject(typeof(GarageLogic.eVehicleType), selectedNumber);

            return selectEnum;
        }

        //public void GetNewVehicle()
        //{
        //    string license_Id = GetLicenseNumber();
        //    if (m_Garage.VehicleExistInGarage(license_Id))
        //    {
        //        m_UI.CarAlreadyInGarage();
        //        m_Garage.setInProgressStatus();
        //        //TODO: notify user that vehicle exist and update status of vehicle

        //    }

        //}
        public string GetLicenseNumber()
        {
             return m_Validator.ValidateLicenseNumber(m_UI.AskingLicenseNumber());

        }

        public int GetNumber(string i_Message)
        {
            string numberString;
            int number = 0;
            bool stringIsNumber = false;

            while (!stringIsNumber)
            {
                m_UI.PrintMessage(i_Message);
                numberString = m_UI.GetInput();
                stringIsNumber = m_Validator.CheckIfInputIsNumber(numberString, out number);
                if (!stringIsNumber)
                {
                    m_UI.ShowFormatMessages();
                    //format exeption
                }
            }

            return number;
        }

        public void CheckNumberForNewStatus(ref int i_Number)
        {
            if (!m_Validator.CheckIfNumberInRangeOfNewStatus(ref i_Number))
            {
                //ValueOutOfRangeException
            }
        }

        public void CheckNumberForTypeOfFuel(ref int i_Number)
        {
            if (!m_Validator.CheckIfNumberInRangeOfNewStatus(ref i_Number))
            {
                //ValueOutOfRangeException
            }
        }

        public void CheckStringForLicenseNumber(string i_String)
        {
            if (!m_Validator.CheckIfStringIsValidLicenseNumber(i_String))
            {
                //ArgumentException
            }
        }


    }
}
