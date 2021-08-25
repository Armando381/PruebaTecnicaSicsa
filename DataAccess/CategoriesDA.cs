using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DataAccess
{
    public class CategoriesDA
    {
        SICSADA dbContext = new SICSADA();
        public Category Add(Category Entity)
        {


            return Entity;
        }
    }
}
