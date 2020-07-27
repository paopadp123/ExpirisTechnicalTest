using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dropdowns.Models.CandidatesSQL.Context
{
    public class CandidatesContext : DbContext
    {
        //public CandidatesContext(DbContext<CandidatesContext> options) : base(options)
        //{

        //}

        public DbSet<CandidatesContext> User { get; set; }
    }
}