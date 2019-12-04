using System;

namespace ChoicesSuperMarket.Domain.Abstract
{
    public class AuditableEntity
    {
        public int Id { get; private set; }
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}