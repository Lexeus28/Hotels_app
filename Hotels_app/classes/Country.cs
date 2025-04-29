using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_app.classes
{
    public class Country
    {
        private Guid _countryId;
        private string _title;

        [Key]
        public Guid сountry_id
        {
            get { return _countryId; }
            set { _countryId = value; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}
