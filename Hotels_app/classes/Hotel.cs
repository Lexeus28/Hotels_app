using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Hotel
{
    // Приватные поля
    private Guid _hotelId;
    private string _hotelName;
    private string _country;
    private string _city;
    private byte _stars;
    private byte[] _image_byte;
    private Image _image;
    private decimal? _mnPrice; // Nullable, так как в таблице может быть NULL
    private decimal? _mxPrice; // Nullable, так как в таблице может быть NULL
    private string _hotelDescription;
    private string _address;
    private bool _hasSeaAccess;
    private bool _hasMountainView;
    private bool _hasHistoricalSites;
    private bool _offersActiveRecreation;
    private bool _hasAsianCuisine;
    private bool _hasEuropeanCuisine;
    private bool _isQuietLocation;
    private bool _isCityCenter;

    // Конструктор по умолчанию
    public Hotel()
    {
        _hotelId = Guid.NewGuid(); // Инициализация уникального идентификатора
    }

    // Свойства с открытым чтением и записью
    [Key]
    public Guid hotel_id
    {
        get { return _hotelId; }
        set { _hotelId = value; }
    }

    public string hotel_name
    {
        get { return _hotelName; }
        set { _hotelName = value; }
    }

    public string country
    {
        get { return _country; }
        set { _country = value; }
    }

    public string city
    {
        get { return _city; }
        set { _city = value; }
    }

    public byte stars
    {
        get { return _stars; }
        set { _stars = value; }
    }
    public byte[] image_byte
    {
        get { return _image_byte; }
        set { _image_byte = value; }
    }
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
                    value.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); // Сохраняем в формате JPEG
                    _image_byte = stream.ToArray(); // Преобразуем в массив байтов
                }
            }
            else
            {
                _image_byte = null;
            }
        }
    }

    public decimal? mn_price
    {
        get { return _mnPrice; }
        set { _mnPrice = value; }
    }

    public decimal? mx_price
    {
        get { return _mxPrice; }
        set { _mxPrice = value; }
    }

    public string hotel_description
    {
        get { return _hotelDescription; }
        set { _hotelDescription = value; }
    }

    public string address
    {
        get { return _address; }
        set { _address = value; }
    }

    public bool has_sea_access
    {
        get { return _hasSeaAccess; }
        set { _hasSeaAccess = value; }
    }

    public bool has_mountain_view
    {
        get { return _hasMountainView; }
        set { _hasMountainView = value; }
    }

    public bool has_historical_sites
    {
        get { return _hasHistoricalSites; }
        set { _hasHistoricalSites = value; }
    }

    public bool offers_active_recreation
    {
        get { return _offersActiveRecreation; }
        set { _offersActiveRecreation = value; }
    }

    public bool has_asian_cuisine
    {
        get { return _hasAsianCuisine; }
        set { _hasAsianCuisine = value; }
    }

    public bool has_european_cuisine
    {
        get { return _hasEuropeanCuisine; }
        set { _hasEuropeanCuisine = value; }
    }

    public bool is_quiet_location
    {
        get { return _isQuietLocation; }
        set { _isQuietLocation = value; }
    }

    public bool is_city_center
    {
        get { return _isCityCenter; }
        set { _isCityCenter = value; }
    }
    public static byte[] ImageToByteArray(Image image)
    {
        if (image == null) return null;

        using (var stream = new MemoryStream())
        {
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); // Или другой формат
            return stream.ToArray();
        }
    }
    public static Image ByteArrayToImage(byte[] byteArray)
    {
        if (byteArray == null || byteArray.Length == 0) return null;

        using (var stream = new MemoryStream(byteArray))
        {
            return Image.FromStream(stream);
        }
    }
}