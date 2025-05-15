using Hotels_app;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels_app
{
    public class UserHotelLike
    {
        private User _user;
        private Guid _user_id;
        private Hotel _hotel;
        private Guid _hotel_id;
        private bool _liked;

        public User user
        {
            get { return _user; }
            set { _user = value; }
        }
        [Key]
        public Guid user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        public Hotel hotel
        {
            get { return _hotel; }
            set { _hotel = value; }
        }
        [Key]
        public Guid hotel_id
        {
            get { return _hotel_id; }
            set { _hotel_id = value; }
        }
        public bool liked
        {
            get { return _liked; }
            set { _liked = value; }
        }
    }
}