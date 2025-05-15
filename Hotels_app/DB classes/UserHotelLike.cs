using System.ComponentModel.DataAnnotations;

namespace Hotels_app
{
    /// <summary>
    /// класс для связи пользователей и их оценок
    /// </summary>
    public class UserHotelLike
    {
        private User _user;
        private Guid _user_id;
        private Hotel _hotel;
        private Guid _hotel_id;
        private bool _liked;

        /// <summary>
        /// Навигационное свойство пользователя
        /// </summary>
        public User user
        {
            get { return _user; }
            set { _user = value; }
        }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key]
        public Guid user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
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
        /// Идентификатор отеля
        /// </summary>
        [Key]
        public Guid hotel_id
        {
            get { return _hotel_id; }
            set { _hotel_id = value; }
        }
        /// <summary>
        /// Оценка пользователя отелю
        /// </summary>
        public bool liked
        {
            get { return _liked; }
            set { _liked = value; }
        }
    }
}