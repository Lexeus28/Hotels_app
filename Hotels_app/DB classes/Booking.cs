using System.ComponentModel.DataAnnotations;
namespace Hotels_app
{
    /// <summary>
    /// класс бронирований
    /// </summary>
    public class Booking
    {
        // Приватные поля
        private Guid _bookingId;
        private Guid _roomId;
        private Guid _userId;
        private Room _room;
        private DateTime _checkInDate;
        private DateTime _checkOutDate;

        /// <summary>
        /// Идентификатор бронирования
        /// </summary>
        [Key]
        public Guid booking_id
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }

        /// <summary>
        /// Идентификатор комнаты
        /// </summary>
        public Guid room_id
        {
            get { return _roomId; }
            set { _roomId = value; }
        }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid user_id
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// Навигационное свойство для связи бронирований с комнатами
        /// </summary>
        public Room room
        {
            get { return _room; }
            set { _room = value; }
        }

        /// <summary>
        /// Дата заезда
        /// </summary>
        public DateTime check_in_date
        {
            get { return _checkInDate; }
            set { _checkInDate = value; }
        }

        /// <summary>
        /// Дата выезда
        /// </summary>
        public DateTime check_out_date
        {
            get { return _checkOutDate; }
            set { _checkOutDate = value; }
        }
    }
}