﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
    public class BrandsClass
    {
        public List<usp_SelectAllBrand_Result> SelectAll()
        {
            ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllBrand().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllBrandsByID_Result> SelectAll(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllBrandsByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }

        public void Delete(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_DeleteAllBrandsByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert(string brandName)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertBrandsByID(brandName); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string brandName ,int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateBrandsByID(brandName , id); }
            catch { }
            finally { db.Dispose(); }
        }
    }
   
}

