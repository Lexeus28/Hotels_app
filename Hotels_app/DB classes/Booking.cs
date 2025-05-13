using System;
using System.ComponentModel.DataAnnotations;

namespace Hotels_app.classes
{
    public class Booking
    {
        // Приватные поля
        private Guid _bookingId;
        private Guid _roomId;
        private Guid _userId;
        private Room _room;
        private DateTime _checkInDate;
        private DateTime _checkOutDate;

        // Свойства с методами доступа
        [Key]
        public Guid booking_id
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }

        public Guid room_id
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        public Guid user_id
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public Room room
        {
            get { return _room; }
            set { _room = value; }
        }

        public DateTime check_in_date
        {
            get { return _checkInDate; }
            set { _checkInDate = value; }
        }

        public DateTime check_out_date
        {
            get { return _checkOutDate; }
            set { _checkOutDate = value; }
        }

        // Конструктор по умолчанию
        public Booking()
        {
            _bookingId = Guid.NewGuid(); // Генерация уникального ID для бронирования
        }

        // Конструктор с параметрами
        public Booking(Guid roomId, Guid userId, DateTime checkInDate, DateTime checkOutDate)
        {
            _bookingId = Guid.NewGuid();
            _roomId = roomId;
            _userId = userId;
            _checkInDate = checkInDate;
            _checkOutDate = checkOutDate;
        }
    }
}