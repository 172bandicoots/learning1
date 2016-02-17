using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace COP4834A02.Models
{
    public class COP4834A02Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public COP4834A02Context() : base("name=COP4834A02Context")
        {
        }

        public System.Data.Entity.DbSet<COP4834A02.Models.ContactForm> ContactForms { get; set; }
    }
}
