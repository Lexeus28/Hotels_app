using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_app
{
    public class User
    {
        private Guid _userId;
        private string _firstName;
        private string _lastName;
        private string _patronymic;
        private string _username;
        private string _passwordHash;
        private string _phone_number;
        // Ответы на анкету
        public bool prefersSea { get; set; }               // Море (true) или Горы (false)
        public bool prefersHistoricalPlaces { get; set; }  // Исторические места (true) или Нет (false)
        public bool prefersActiveRest { get; set; }        // Активный отдых (true) или Спокойный (false)
        public bool prefersAsianCuisine { get; set; }      // Азиатская кухня (true) или Европейская (false)
        public bool prefersQuietPlace { get; set; }        // Тихая местность (true) или Шумный город (false)

        public Guid user_id
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string first_name
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string last_name
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string patronymic
        {
            get { return _patronymic; }
            set { _patronymic = value; }
        }

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string password_hash
        {
            get { return _passwordHash; }
            set { _passwordHash = value; }
        }

        public string phone_number
        {
            get { return _phone_number; }
            set { _phone_number = value; }
        }
    }
}
