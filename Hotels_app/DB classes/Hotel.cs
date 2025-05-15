using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hotels_app
{
    /// <summary>
    /// класс отелей
    /// </summary>
    public class Hotel
    {
        // Приватные поля
        private Guid _hotelId;
        private string _hotelName;
        private City _city;
        private byte? _stars;
        private byte[]? _image_byte;
        private Image _image;
        private decimal? _mnPrice;
        private decimal? _mxPrice;
        private string _hotelDescription;
        private string _address;
        private bool _hasSeaAccess;
        private bool _hasMountainView;
        private bool _hasHistoricalSites;
        private bool _offersActiveRecreation;
        private bool _hasAsianCuisine;
        private bool _hasEuropeanCuisine;
        private bool _isCityCenter;

        /// <summary>
        /// Айди отеля
        /// </summary>
        [Key]
        public Guid hotel_id
        {
            get { return _hotelId; }
            set { _hotelId = value; }
        }

        /// <summary>
        /// Название отеля
        /// </summary>
        public string hotel_name
        {
            get { return _hotelName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название отеля не может быть пустым.", nameof(value));
                }
                if (value.Length > 35)
                {
                    throw new ArgumentException("Название отеля не должно превышать 35  символов.", nameof(value));
                }
                _hotelName = value;
            }
        }

        /// <summary>
        /// Навигационное свойство для связи городов с отелями
        /// </summary>
        public City city
        {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// Количество звёзд у отеля
        /// </summary>
        public byte? stars
        {
            get { return _stars; }
            set { _stars = value; }
        }

        /// <summary>
        /// Картинка, хранящаяся в массиве байтов
        /// </summary>
        public byte[]? image_byte
        {
            get { return _image_byte; }
            set { _image_byte = value; }
        }

        /// <summary>
        /// Навигационное свойство для загрузки картинок
        /// </summary>
        [NotMapped]
        public Image image
        {
            get
            {
                if (_image == null && _image_byte != null)
                {
                    using (var stream = new MemoryStream(_image_byte))
                    {
                        _image = Image.FromStream(stream);
                    }
                }
                return _image;
            }
            set
            {
                _image = value;
                if (value != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        value.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        _image_byte = stream.ToArray();
                    }
                }
                else
                {
                    _image_byte = null;
                }
            }
        }

        /// <summary>
        /// Минимальная ценв номера в отеле
        /// </summary>
        public decimal? mn_price
        {
            get { return _mnPrice; }
            set { _mnPrice = value; }
        }

        /// <summary>
        /// Максимальная цена номера в отеле
        /// </summary>
        public decimal? mx_price
        {
            get { return _mxPrice; }
            set { _mxPrice = value; }
        }

        /// <summary>
        /// Описание отеля
        /// </summary>
        public string hotel_description
        {
            get { return _hotelDescription; }
            set
            {
                if (value != null && value.Length > 90)
                    throw new ArgumentException("Описание отеля не должно превышать 90 символов.", nameof(hotel_description));
                _hotelDescription = value;
            }
        }

        /// <summary>
        /// Адрес отеля
        /// </summary>
        public string address
        {
            get { return _address; }
            set
            {
                if (value != null && value.Length > 50)
                    throw new ArgumentException("Название адреса не должно превышать 25 символов.");
                _address = value;
            }
        }

        /// <summary>
        /// свойство, проверяющее есть ли у отеля доступ к морю
        /// </summary>
        public bool has_sea_access
        {
            get { return _hasSeaAccess; }
            set { _hasSeaAccess = value; }
        }

        /// <summary>
        /// свойство, проверяющее есть ли у отеля вид на горы
        /// </summary>
        public bool has_mountain_view
        {
            get { return _hasMountainView; }
            set { _hasMountainView = value; }
        }

        /// <summary>
        /// свойство, проверяющее есть ли рядом с отелем исторические места
        /// </summary>
        public bool has_historical_sites
        {
            get { return _hasHistoricalSites; }
            set { _hasHistoricalSites = value; }
        }

        /// <summary>
        /// свойство, проверяющее есть ли у отеля активные виды отдыха
        /// </summary>
        public bool offers_active_recreation
        {
            get { return _offersActiveRecreation; }
            set { _offersActiveRecreation = value; }
        }

        /// <summary>
        /// свойство, проверяющее есть ли у отеля азиатская кухня
        /// </summary>
        public bool has_asian_cuisine
        {
            get { return _hasAsianCuisine; }
            set { _hasAsianCuisine = value; }
        }

        /// <summary>
        /// свойство, проверяющее есть ли у отеля европейская кухня
        /// </summary>
        public bool has_european_cuisine
        {
            get { return _hasEuropeanCuisine; }
            set { _hasEuropeanCuisine = value; }
        }

        /// <summary>
        /// свойство, проверяющее находится ли отель в центре города
        /// </summary>
        public bool is_city_center
        {
            get { return _isCityCenter; }
            set { _isCityCenter = value; }
        }
        /// <summary>
        /// Конвертирует изображение в массив байтов.
        /// </summary>
        /// <param name="image">Изображение, которое нужно преобразовать. Если null, метод вернет null.</param>
        /// <returns>Массив байтов, представляющий изображение в формате JPEG, или null, если изображение отсутствует.</returns>
        public static byte[] ImageToByteArray(Image image)
        {
            if (image == null) return null;

            using (var stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }
        /// <summary>
        /// Конвертирует массив байтов в изображение.
        /// </summary>
        /// <param name="byteArray">Массив байтов, представляющий изображение. Если массив пустой или null, метод вернет null.</param>
        /// <returns>Изображение, созданное из массива байтов, или null, если входной массив некорректен.</returns>
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;

            using (var stream = new MemoryStream(byteArray))
            {
                return Image.FromStream(stream);
            }
        }
    }
}