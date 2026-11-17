using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class ClsCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ClsCategory()
        {
            CategoryId = 0;
            CategoryName = "";
        }

        public static List<CategoriesDTO> GetAllCategories()
        {
            return ClsCategoryDataAccessLayer.GetAllCategories();
        }

    }
}
