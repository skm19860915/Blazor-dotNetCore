using Ortho.Shared.Enums;
using System;

namespace Ortho.Shared.Mappings
{
    public static class LISColumnDragAndDropMapping
    {
        public static string Date;
        public static string Time;
        public static string SampleID;
        public static string AssayCode;
        public static string SpecimenType;
        public static string Priority;
        public static string Location;
        public static string ResultTime;


        public static void AssignLISFileData(string data, ConfigLisField zone)
        {
            switch (zone)
            {
                case ConfigLisField.Date:
                    Date = data;
                    break;
                case ConfigLisField.Time:
                    Time = data;
                    break;
                case ConfigLisField.SampleID:
                    SampleID = data;
                    break;
                case ConfigLisField.AssayCode:
                    AssayCode = data;
                    break;
                case ConfigLisField.SpecimenType:
                    SpecimenType = data;
                    break;
                case ConfigLisField.Priority:
                    Priority = data;
                    break;
                case ConfigLisField.Location:
                    Location = data;
                    break;
                case ConfigLisField.ResultTime:
                    ResultTime = data;
                    break;
            }
        }

        public static string ToGetData(this string assignedData)
        {
            if(string.IsNullOrEmpty(assignedData))
                return null;

            var data = assignedData.Split(':');
            return data[2];
        }

        public static int? ToGetHeaderId(this string assignedData)
        {
            if (string.IsNullOrEmpty(assignedData))
                return null;

            var data = assignedData.Split(':');
            return Convert.ToInt32(data[0]);
        }

        public static string ToGetHeaderName(this string assignedData)
        {
            if (string.IsNullOrEmpty(assignedData))
                return null;

            var data = assignedData.Split(':');
            return data[1];
        }
    }
}
