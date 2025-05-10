using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_app.classes
{
    public class City
    {
        private Guid _cityId;
        private string _title;

        [Key]
        public Guid city_id
        {
            get { return _cityId; }
            set { _cityId = value; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}
