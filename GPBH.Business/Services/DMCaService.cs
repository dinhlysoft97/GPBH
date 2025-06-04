using GPBH.Data;
using GPBH.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPBH.Business.Services
{
    public class DMCaService
    {
            public List<DMca> GetAll()
            {
                using (var db = new AppDbContext())
                {
                    return db.DMca.ToList();
                }
            }
    }
}
