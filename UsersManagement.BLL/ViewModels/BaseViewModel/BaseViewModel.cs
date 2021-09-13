using System;
using System.Collections.Generic;
using System.Text;

namespace UsersManagement.Bll.ViewModels.BaseViewModel
{
    public class BaseViewModel<T>
    {
        public  T ID { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

    }
}
