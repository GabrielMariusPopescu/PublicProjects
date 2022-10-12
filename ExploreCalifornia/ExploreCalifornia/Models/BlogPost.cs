using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ExploreCalifornia.Models
{
    public class BlogPost
    {
        public long Id { get; set; }

        public string Key
        {
            get
            {
                if (string.IsNullOrEmpty(key))
                    key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");

                return key;
            }

            set => key = value;
        }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 characters long")]
        public string Title { get; set; }

        public string Author { get; set; }

        [Required]
        [MinLength(100, ErrorMessage = "Blog posts must be at least 100 characters long")]
        public string Body { get; set; }

        public DateTime Posted { get; set; }

        //

        private string key;
    }
}
