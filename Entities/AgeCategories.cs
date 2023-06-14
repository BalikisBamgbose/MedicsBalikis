using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Entities
{
    public class AgeCategories : BaseEntity
    {
       
        public string AgeId {get; set;}
        public Age Age {get; set;}
        public string CategoriesId {get; set;}
        public Categories Categories {get; set;}
    }
}