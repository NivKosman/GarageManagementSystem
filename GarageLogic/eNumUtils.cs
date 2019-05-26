using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public static class eNumUtils
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        public static bool TryParseEnum<T>(string value, out T o_Result)
        {
            bool ignoreCase = true;
            bool retVal = true;
            o_Result = default(T);
            try
            {
                o_Result = (T)Enum.Parse(typeof(T), value, ignoreCase);
            }
            catch (Exception ex)
            {
                retVal = false; 
            }

            return retVal;
        }
    }
}
