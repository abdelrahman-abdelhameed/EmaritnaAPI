using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace Emaritna.Bll.ViewModels.Base
{
    public class BaseViewModel<T>
    {
        public T ID { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreateAt { get; set; } = Convert.ToDateTime(DateTime.Now, new CultureInfo("en-US"));

    }

}