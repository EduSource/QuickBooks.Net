using System;

namespace QuickBooks.Net.Data.Models.Fields
{
    public class MetaData
    {
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }

        public override string ToString()
        {
            return $"Create Time - {CreateTime} : Last Update - {LastUpdatedTime}";
        }
    }
}