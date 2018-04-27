using System;

namespace NexusCanadaTech.Web.API.Core.DbModels
{
    public abstract class BaseDbModel
    {
        public  virtual ModelStatus ChangeStatus
        {
            get
            {
                if (this.IsDeleted)
                {
                    return ModelStatus.Deleted;
                }

                if (this.DateCreated == this.DateModified)
                {
                    return ModelStatus.New;
                }

                return ModelStatus.Updated;
            }
        }

        //// public virtual int CreatedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }

        public virtual bool IsDeleted { get; set; }

        //// public virtual int UpdatedBy { get; set; }
        public virtual DateTime? DateModified { get; set; }
    }
}
