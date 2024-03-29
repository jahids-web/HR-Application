﻿using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModel
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class DepartmentViewModelValidator : AbstractValidator<DepartmentViewModel>
    {
        public DepartmentViewModelValidator()
        {
            RuleFor(x => x.DepartmentId).NotNull().NotEmpty();
            RuleFor(x => x.DepartmentName).NotNull().NotEmpty();
        }
    }
}
