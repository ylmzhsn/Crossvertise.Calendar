namespace Crossvertise.Calender.Data.Abstract
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Base entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseEntity<T>
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public T Id { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
