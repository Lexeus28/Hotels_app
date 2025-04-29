using System;
using System.ComponentModel.DataAnnotations;

public class Hotel
{
    // Приватные поля
    private Guid _hotelId;
    private string _hotelName;
    private string _country;
    private string _city;
    private byte _stars;
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

    public bool hasSeaAccess
    {
        get { return _hasSeaAccess; }
        set { _hasSeaAccess = value; }
    }

    public bool hasMountainView
    {
        get { return _hasMountainView; }
        set { _hasMountainView = value; }
    }

    public bool hasHistoricalSites
    {
        get { return _hasHistoricalSites; }
        set { _hasHistoricalSites = value; }
    }

    public bool offersActiveRecreation
    {
        get { return _offersActiveRecreation; }
        set { _offersActiveRecreation = value; }
    }

    public bool hasAsianCuisine
    {
        get { return _hasAsianCuisine; }
        set { _hasAsianCuisine = value; }
    }

    public bool hasEuropeanCuisine
    {
        get { return _hasEuropeanCuisine; }
        set { _hasEuropeanCuisine = value; }
    }

    public bool isQuietLocation
    {
        get { return _isQuietLocation; }
        set { _isQuietLocation = value; }
    }

    public bool isCityCenter
    {
        get { return _isCityCenter; }
        set { _isCityCenter = value; }
    }
}