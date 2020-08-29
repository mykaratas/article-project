namespace article.data.models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface ICoreEntity { }
    public abstract class CoreEntity : ICoreEntity
    {
        public CoreEntity()
        {
            this.Id = Guid.NewGuid();
            this.CreatedDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}