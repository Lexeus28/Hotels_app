using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_app.classes
{
    public class City
    {
        private Guid _cityId;
        private string _title;
        private Guid _countryId;

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

        public Guid country_id
        {
            get { return _countryId; }
            set { _countryId = value; }
        }
    }
}
