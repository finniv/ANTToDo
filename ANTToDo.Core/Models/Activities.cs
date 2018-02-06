using System;
using SQLite;

namespace ANTToDo.Core.Models
{
    [Table(nameof(Activities))]
    public class Activities
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull, MaxLength(250)]
        public string ActivitiesTitle { get; set; }

        [MaxLength(250)]
        public string ActivitiesDescription { get; set; }

        [NotNull]
        public int ActivitiesStatus { get; set; }

        public bool IsValid()
        {
            return (!String.IsNullOrWhiteSpace(ActivitiesTitle));
        }
    }
}
