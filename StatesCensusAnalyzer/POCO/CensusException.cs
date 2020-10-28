using System;
using System.Collections.Generic;
using System.Text;

namespace StatesCensusAnalyzer
{
    public class CensusException : Exception
    {
        public enum ExceptionType
        {
            File_Not_Found, Invalid_File_Type, Incorrect_Header, Incorrect_Delimiter, No_Such_Country
        }
        public ExceptionType type;
        public CensusException(string message, ExceptionType Type) : base(message)
        {
            this.type = Type;
        }
    }
}
