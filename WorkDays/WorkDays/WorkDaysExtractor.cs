namespace WorkDays
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using HtmlAgilityPack;

    public class WorkDaysExtractor
    {
        private static readonly string Url = "http://pochivnidni.eu/" + DateTime.Now.Year;

        private HtmlDocument _document;

        public WorkDaysExtractor()
        {
            _document = new HtmlWeb().Load(Url);
        }

        public List<Month> GetWorkDays()
        {
            var months = new List<Month>();
            var calendar = _document.DocumentNode.SelectSingleNode("//div[contains(@class, \"calendar-wrapper\")]");

            var month = calendar.SelectNodes("div[contains(@class, 'row')]/div[contains(@class, 'month-wrapper')]");
            foreach (var m in month)
            {
                var monthIndex = int.Parse(m.Attributes["data-month"].Value);
                months.Add(GetWorkDaysFor(m, monthIndex));
            }

            return months;
        }

        private Month GetWorkDaysFor(HtmlNode node, int monthIndex)
        {
            var month = new Month(monthIndex);

            foreach (var day in node.SelectNodes("table/tr/td[contains(@class, 'day')]"))
            {
                if (day.Attributes["class"].Value.Contains("on") || day.Attributes["class"].Value.Contains("normal"))
                {
                    month.AddWorkDay(int.Parse(Regex.Replace(day.InnerText, @"/^d+", "")));
                }
            }

            return month;
        }
    }
}
