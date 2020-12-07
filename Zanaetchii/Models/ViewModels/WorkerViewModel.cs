using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zanaetchii.Models.ViewModels
{
    public class WorkerViewModel
    {
        public int Id { get; set; }


        public  UserViewModel User { get; set; }

        
        public WorkFieldViewModel Workfield { get; set; }
    }
}
