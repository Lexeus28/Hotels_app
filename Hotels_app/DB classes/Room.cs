using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Hotels_app.classes
{
    public class Room
    {
        private Guid _roomId;
        private Hotel _hotel;
        private string _name;
        private decimal _pricePerNight;
        private int _capacity;
        private int _amount;
        private string _description;
        private Image _image;
        private byte[]? _imageByte;
        [Key]
        public Guid room_id
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        public Hotel hotel
        {
            get { return _hotel; }
            set { _hotel = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal price_per_night
        {
            get { return _pricePerNight; }
            set { _pricePerNight = value; }
        }

        public int capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
        public int amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string room_description
        {
            get { return _description; }
            set { _description = value; }
        }

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

        public byte[]? image_byte
        {
            get { return _imageByte; }
            set { _imageByte = value; }
        }
    }
}