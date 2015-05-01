namespace WorkDays
{
    using System;

    class Program
    {
        static void Main()
        {
            var extractor = new WorkDaysExtractor();
            var model = extractor.GetWorkDays();

            foreach (var month in model)
            {
                Console.WriteLine("{0}: {1}", month.Name, month.WorkDays.Count);
            }
        }
    }
}
