namespace BookingManagement.Domain.RecordEntitys
{
    public abstract class RecordEntity<TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual TKey Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime CreationTime { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid CreatedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? LastModifiedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? DeletionTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Guid? DeletedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsDeleted { get; set; }
    }

}
