namespace WorkDays
{
    using System;
    using System.Collections.Generic;

    public class Month
    {
        private static readonly string[] Months = 
        {
            "January", "Febuary", "March", "April",
            "May", "June", "July", "August", 
            "September", "October", "November", "December"
        };

        public Month(int monthIndex)
        {
            if (monthIndex < 1 || monthIndex > 12)
            {
                throw new ArgumentOutOfRangeException("monthIndex");
            }

            Name = Months[monthIndex - 1];
            WorkDays = new List<int>();
        }

        public string Name { get; private set; }

        public List<int> WorkDays { get; private set; }

        public void AddWorkDay(int day)
        {
            WorkDays.Add(day);
        }
    }
}
