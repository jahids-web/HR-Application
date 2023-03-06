using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModel
{
    public class LeaveApplicationViewModel
    {
        public string LeaveApplicationId { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string Subject { get; set; } 
        public string Body { get; set; } 
        public string Status { get; set; }  
        public string From { get; set; }    
        public string To { get; set; }
        public DateTime ApprovalDate { get; set; }  
        public DateTime ApplicationDate { get; set; }
        public string LastUpdatedAt { get; set; }
        public string EmployeeId { get; set;}
    }

    public class LeaveApplicationViewModelValidator : AbstractValidator<LeaveApplicationViewModel>
    {
        public LeaveApplicationViewModelValidator()
        {
            RuleFor(x => x.LeaveApplicationId).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.DepartmentName).NotNull().NotEmpty();
            RuleFor(x => x.Subject).NotNull().NotEmpty();
            RuleFor(x => x.Body).NotNull().NotEmpty();
            RuleFor(x => x.Status).NotNull().NotEmpty();
            RuleFor(x => x.From).NotNull().NotEmpty();
            RuleFor(x => x.To).NotNull().NotEmpty();
            RuleFor(x => x.ApprovalDate).NotNull().NotEmpty();
            RuleFor(x => x.ApplicationDate).NotNull().NotEmpty();
            RuleFor(x => x.LastUpdatedAt).NotNull().NotEmpty();
            RuleFor(x => x.EmployeeId).NotNull().NotEmpty();
        }
    }
}
