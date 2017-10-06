using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_FluentValidation.ViewModels
{
    public class AddMovieViewModel
    {
        [Required(ErrorMessage = "Please enter a title.")]
        [Display(Name = "Title:")]
        [StringLength(100, ErrorMessage = "The title must be less than 100 characters.")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date:")]
        [Required(ErrorMessage = "Please enter a release date.")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Running Time:")]
        [Required(ErrorMessage = "Please enter the running time.")]
        [Range(0, int.MaxValue, ErrorMessage = "The Running Time cannot be negative")]
        public int RunningTimeMinutes { get; set; }

        [Display(Name = "Leading Actor:")]
        [Required(ErrorMessage = "Please enter the leading actor.")]
        public string LeadingActor { get; set; }

        [Display(Name = "Supporting Actor:")]
        public string SupportingActor { get; set; }
    }
}