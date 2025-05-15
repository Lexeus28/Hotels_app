using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Hotels_app
{
    /// <summary>
    /// класс пользователей
    /// </summary>
    public class User
    {
        private Guid _userId;
        private string _firstName;
        private string _lastName;
        private string? _patronymic;
        private string _username;
        private string _passwordHash;
        private string _phone_number;

        /// <summary>
        /// Своство, проверяющее, предпочитает ли пользователь море или горы
        /// </summary>
        public bool? prefers_sea { get; set; }               // Море (true) или Горы (false)
        /// <summary>
        /// Своство, проверяющее, предпочитает ли пользователь исторические места
        /// </summary>
        public bool? prefers_historical_places { get; set; }  // Исторические места (true) или Нет (false)
        /// <summary>
        /// Своство, проверяющее, предпочитает ли пользователь активный отдых
        /// </summary>
        public bool? prefers_active_rest { get; set; }        // Активный отдых (true) или Спокойный (false)
        /// <summary>
        /// Своство, проверяющее, предпочитает ли пользователь азиатскую кухню
        /// </summary>
        public bool? prefers_asian_cuisine { get; set; }      // Азиатская кухня (true) или Европейская (false)
        /// <summary>
        /// Своство, проверяющее, предпочитает ли пользователь спокойные места
        /// </summary>
        public bool? prefers_quiet_place { get; set; }        // Тихая местность (true) или Шумный город (false)
        /// <summary>
        /// Своство, проверяющее, в первый ли раз пользователь заходит в учётную запись
        /// </summary>
        public bool isfirstlogin { get; set; } = true;
        /// <summary>
        /// Роль пользователя
        /// </summary>
        [Column(TypeName = "varchar(50)")] // Храним роль как строку
        public Role role { get; set; } = Role.User;

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key]
        public Guid user_id
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string first_name
        {
            get { return _firstName; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым.", nameof(value));
                if (value.Length > 50)
                   throw new ArgumentException("Имя не должно превышать 50 символов.", nameof(value));
                if (!Regex.IsMatch(value, @"^[А-ЯЁ][а-яё]*$"))
                    throw new ArgumentException("Имя должно начинаться с заглавной буквы и содержать только буквы.", nameof(value));
                _firstName = value;
            }
        }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string last_name
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Фамилия не может быть пустой.", nameof(value));
                if (value.Length > 50)
                    throw new ArgumentException("Фамилия не должна превышать 50 символов.", nameof(value));
                if (!Regex.IsMatch(value, @"^[А-ЯЁ][а-яё]*$"))
                    throw new ArgumentException("Фамилия должна начинаться с заглавной буквы и содержать только буквы.", nameof(value));
                _lastName = value;
            }
        }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string? patronymic
        {
            get { return _patronymic; }
            set
            {
                if (value != null && !Regex.IsMatch(value, @"^[А-ЯЁ][а-яё]*$"))
                    throw new ArgumentException("Отчество должно начинаться с заглавной буквы и содержать только буквы.", nameof(value));
                if (value?.Length > 50)
                    throw new ArgumentException("Отчество не должно превышать 50 символов.", nameof(value));
                _patronymic = value;
            }
        }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string username
        {
            get { return _username; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Логин не может быть пустым.", nameof(value));
                if (value.Length > 50)
                    throw new ArgumentException("Логин не должен превышать 50 символов.", nameof(value));
                if (value.Length < 6)
                    throw new ArgumentException("Логин должен быть больше 6 символов.", nameof(value));
                _username = value;
            }
        }

        /// <summary>
        /// Хэшированный пароль пользователя
        /// </summary>
        public string password_hash
        {
            get { return _passwordHash; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Пароль не может быть пустым.");
                if ((value).Length < 6)
                    throw new ArgumentException("Пароль должен быть меньше 6 символов.", nameof(value));
                _passwordHash = value;
            }
        }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        public string phone_number
        {
            get { return _phone_number; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер телефона не может быть пустым.", nameof(value));
                if (!Regex.IsMatch(value, @"^[0-9]{9,15}$"))
                    throw new ArgumentException("Номер телефона должен содержать цифры (1-15).", nameof(value));
                _phone_number = value;
            }
        }
    }
}