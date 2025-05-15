using System.ComponentModel.DataAnnotations;
namespace Hotels_app
{
    /// <summary>
    /// класс городов
    /// </summary>
    public class City
    {
        private Guid _cityId;
        private string _title;

        /// <summary>
        /// Айди города
        /// </summary>
        [Key]
        public Guid city_id
        {
            get { return _cityId; }
            set { _cityId = value; }
        }

        /// <summary>
        /// Название города
        /// </summary>
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}