using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotels_app
{
    /// <summary>
    /// класс комнат
    /// </summary>
    public class Room
    {
        private Guid _roomId;
        private Hotel _hotel;
        public ICollection<Booking> _bookings;
        private string _name;
        private decimal _pricePerNight;
        private int _capacity;
        private int _amount;
        private string _description;
        private Image _image;
        private byte[]? _imageByte;
        /// <summary>
        /// Идентификатор комнаты
        /// </summary>
        [Key]
        public Guid room_id
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        /// <summary>
        /// Навигационное свойство отеля
        /// </summary>
        public Hotel hotel
        {
            get { return _hotel; }
            set { _hotel = value; }
        }

        /// <summary>
        /// Навигационное свойство бронирований
        /// </summary>
        public ICollection<Booking> bookings
        {
            get { return _bookings; }
            set { _bookings = value; }
        }

        /// <summary>
        /// Название комнаты
        /// </summary>
        public string name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название номера не может быть пустым.", nameof(value));
                if (value.Length > 35)
                    throw new ArgumentException("Название номера не должно превышать 35 символов.", nameof(value));
                _name = value;
            }
        }

        /// <summary>
        /// Цена за ночь
        /// </summary>
        public decimal price_per_night
        {
            get { return _pricePerNight; }
            set
            {
                if (!decimal.TryParse(value.ToString(), out decimal parsedValue))
                    throw new ArgumentException("Цена за ночь должна содержать только числовые значения.");
                if (parsedValue <= 0)
                    throw new ArgumentException("Цена за ночь должна быть больше 0.");

                _pricePerNight = parsedValue;
            }
        }

        /// <summary>
        /// Вместимость комнаты
        /// </summary>
        public int capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        /// <summary>
        /// Количество таких комнат
        /// </summary>
        public int amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        /// <summary>
        /// Описание комнаты
        /// </summary>
        public string room_description
        {
            get { return _description; }
            set
            {
                if (value.Length > 70)
                    throw new ArgumentException("Описание номера не должно превышать 70 символов.");
                _description = value;
            }
        }

        /// <summary>
        /// Навигационное свойство для загрузки картинки
        /// </summary>
        [NotMapped]
        public Image image
        {
            get
            {
                if (_image == null && _imageByte != null)
                {
                    _image = Hotel.ByteArrayToImage(_imageByte); // Используем метод из класса Hotel
                }
                return _image;
            }
            set
            {
                _image = value;
                if (value != null)
                {
                    _imageByte = Hotel.ImageToByteArray(value); // Используем метод из класса Hotel
                }
                else
                {
                    _imageByte = null;
                }
            }
        }

        /// <summary>
        /// Картинка, хранящаяся в массиве байтов
        /// </summary>
        public byte[]? image_byte
        {
            get { return _imageByte; }
            set { _imageByte = value; }
        }
    }
}