using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
    class CarModelClass
    {
        public List<usp_SelectAllCars_Result> SelectAll()
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_SelectAllCars().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllCarsByID_Result> SelectAll(int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_SelectAllCarsByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllCarsByBrandID_Result> SelectAllByBrand(int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_SelectAllCarsByBrandID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_DeleteAllCarsByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert(string carModel, int brandID,string  motorCap,string man_Year)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_InsertCarsByID(carModel, brandID, motorCap, man_Year); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string carModel, int brandID, string motorCap, string man_Year,int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_UpdateCarsByID(carModel, brandID, motorCap, man_Year, id); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
