using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class UI
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
         
        public void PrintMenu()
        {
               Console.WriteLine(Messages.GarageMenu);
        }

        public void PrintMessage(string i_MessageToPrint)
        {
            Console.WriteLine(i_MessageToPrint);
        }

        public string AskingLicenseNumber()
        {
            PrintMessage(Messages.AskingLicenseNumber);

            return GetInput();
        }
        public int GetOptionInput()
        {
            string inputStr = GetInput();
            int inputNum;
            bool isNumber = int.TryParse(inputStr, out inputNum);
            if (!isNumber)
            {
                PrintMessage(Messages.InvalidOptionSelected);
                return GetOptionInput();
            }
            else
            {
                return inputNum;
            }
        }

        public int GetIntInRange(int i_min, int i_max)
        {
            int num = GetIntNumber();
            if (num < i_min || num > i_max)
            {
                return GetIntInRange(i_min, i_max); 
            }
            else
            {
                return num;
            }
        }

        public bool GetBool()
        {
            int boolNumber = GetIntNumber();
            bool retVal = false;
            if (boolNumber == 0 )
            {
                retVal = false; 
            }
            else if (boolNumber == 1)
            {
                retVal = true; 
            }
            else
            {
                return GetBool(); 
            }

            return retVal;
        }

        public int GetIntNumber()
        {
            string inputStr = GetInput();
            int inputNum;
            bool isNumber = int.TryParse(inputStr, out inputNum);
            if (!isNumber)
            {
                PrintMessage(Messages.InvalidNumberEntered);
                return GetIntNumber();
            }
            else
            {
                return inputNum;
            }
        }
        public float GetFloatInput() 
        {
            string inputStr = GetInput();
            float inputNum;
            bool isNumber = float.TryParse(inputStr, out inputNum);
             if (!isNumber)
            {
                PrintMessage(Messages.InvalidNumberEntered);
                return GetFloatInput(); 
            }
            else 
            {
                return inputNum; 
            }
        }
        public void ShowOptionFromArray(string i_Message, System.Array i_Options)
        {
            PrintMessage(i_Message);
            for (int i = 0; i < i_Options.Length; i++)
            {
                string option = string.Format("{0} - {1}{2}", (int)i_Options.GetValue(i), i_Options.GetValue(i), Environment.NewLine);
                PrintMessage(option);
            }
        }

        public void ShowOptions<T>(string i_Message, IEnumerable<T> i_Options)
        {
            PrintMessage(i_Message);
            for (int i = 0; i < i_Options.Count(); i++)
            {
                string option = string.Format("{0} - {1}{2}", i+1, i_Options.ElementAt(i), Environment.NewLine);
                PrintMessage(option);
            }
        }

        public string AskingTypeOfFuel()
        {
            PrintMessage(Messages.AskingTypeOfFuel);

            return GetInput();
        }

        public string AskingAmountOfFuel()
        {
            PrintMessage(Messages.AskingAmountOfFuel);

            return GetInput();
        }

        public string AskingAmountOfMinutes()
        {
            PrintMessage(Messages.AskingAmountOfMinutes);

            return GetInput();
        }

        public void CarAlreadyInGarage()
        {
            PrintMessage(Messages.CarAlreadyInGarage);
        }

        public string AskingNewStatusOfVehicle()
        {
            PrintMessage(Messages.AskingNewStatusOfVehicle);

            return GetInput();
        }

        public void WrongNumberOfTypeOfFuel()
        {
            PrintMessage(Messages.WrongNumberOfTypeOfFuel);
        }

        public void WrongNumberOfOptionOfStatus()
        {
            PrintMessage(Messages.WrongNumberOfOptionOfStatus);
        }

        public void ShowFormatMessages()
        {
            PrintMessage(Messages.FormatMessages);
        }

        public void ShowWrongFuel()
        {
            PrintMessage(Messages.WrongFuel);
        }

        public void ShowTooMuchFuel()
        {
            PrintMessage(Messages.TooMuchFuel);
        }

        public void ShowTooMuchMinutes()
        {
            PrintMessage(Messages.TooMuchMinutes);
        }
    }
}
