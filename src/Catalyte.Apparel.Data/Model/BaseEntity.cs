using System;
using System.ComponentModel.DataAnnotations;

namespace Catalyte.SuperHealth.Data.Model
{
    /// <summary>
    /// This class represents a base for all other entities.
    /// </summary>
    public class BaseEntity
    {

        [Key]
        public int Id { get; set; }

        public DateTime LastActive { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

    }

}
