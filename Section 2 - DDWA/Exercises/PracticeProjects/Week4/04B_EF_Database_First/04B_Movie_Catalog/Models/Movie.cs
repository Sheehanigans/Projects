//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _04B_Movie_Catalog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        public int MovieId { get; set; }
        public Nullable<int> RatingId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
    
        public virtual Genre Genre { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
