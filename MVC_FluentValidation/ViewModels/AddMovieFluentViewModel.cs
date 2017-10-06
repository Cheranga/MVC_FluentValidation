using System;
using FluentValidation.Attributes;
using MVC_FluentValidation.Validators;

namespace MVC_FluentValidation.ViewModels
{
    [Validator(typeof (AddMovieViewModelValidator))]
    public class AddMovieFluentViewModel
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunningTimeMinutes { get; set; }
        public string LeadingActor { get; set; }
        public string SupportingActor { get; set; }
    }
}