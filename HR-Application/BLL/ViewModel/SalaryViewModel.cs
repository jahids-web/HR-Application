using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModel
{
    public class SalaryViewModel
    {
        public string EmployeeSalaryId { get; set; }
        public string Name { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public string PostedAt { get; set; }
        public string PostedBy { get; set; }
        public string IsProvided { get; set; }
    }

    public class SalaryViewModelValidator : AbstractValidator<SalaryViewModel>
    {
        public SalaryViewModelValidator()
        {

            RuleFor(x => x.EmployeeSalaryId).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Month).NotNull().NotEmpty();
            RuleFor(x => x.Year).NotNull().NotEmpty();
            RuleFor(x => x.PostedAt).NotNull().NotEmpty();
            RuleFor(x => x.PostedBy).NotNull().NotEmpty();
            RuleFor(x => x.IsProvided).NotNull().NotEmpty();
        }
    }
}
