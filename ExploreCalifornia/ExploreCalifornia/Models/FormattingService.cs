using System;

namespace ExploreCalifornia.Models
{
    public class FormattingService
    {
        public string AsReadableDate(DateTime dateTime) => dateTime.ToString("D");
    }
}
