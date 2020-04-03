using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
 public   class CityClass
    {
        public List<usp_SelectAllCity_Result> SelectAll()
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_SelectAllCity().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllCityByID_Result> SelectAll(int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_SelectAllCityByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_DeleteAllCityByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert( string cityName)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_InsertNewCity(cityName); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string cityName ,int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_UpdateNewCity(cityName ,id); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
