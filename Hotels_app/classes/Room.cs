using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_app.classes
{
    public class Room
    {
        private Guid _roomId;
        private Hotel _hotel;
        private string _roomNumber;
        private decimal _pricePerNight;
        private int _capacity;
        private string _description;
        private Image _image;

        public Guid RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        public Hotel hotel
        {
            get { return _hotel; }
            set { _hotel = value; }
        }

        public string room_number
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
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

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        public Image image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
