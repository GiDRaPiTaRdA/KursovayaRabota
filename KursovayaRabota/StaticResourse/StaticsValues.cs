using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticResourse
{
    public class StaticValues
    {
        #region Task
        public static string defaultNameOfTask = "Name is missing";
        public static string defaultPurposeOfTask = "Purpose is missing";
        public static int defaultTaskState = 0;
        public static int defaultTaskImportance = 1;
        #endregion

        #region StringHelper
        public static string badNameFormatExceptionMessage = "Bad name format exception";
        public static string badNameFormatExceptionExtendedMessage = "The name must have at least one charachter, where the first one is upper letter.";
        #endregion

        #region Team
        public static string defaultNameOfTeam = "Default team name";
        public static int defaultPostValue = 0;
        public static string defaultNameOfExecutor = "Name is missing";
        #endregion

        #region Plan
        public static string defaultNameOfPlan = "Default plan name";

        public enum EPost
        {
            Temporary,
            Developer,
            ProjectManager,
            Designer,
            TeamLeader
        }
        #endregion
    }
}
