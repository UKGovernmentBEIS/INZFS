using INZFS.MVC.Models.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INZFS.MVC.ViewModels
{
    public class RefrenceNumberViewModel : RefrenceNumberPart
    {

        [BindNever]
        public RefrenceNumberPart RefrenceNumberPart { get; set; }
    }
}