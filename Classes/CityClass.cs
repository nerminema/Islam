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
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllCity().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllCityByID_Result> SelectAll(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllCityByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_DeleteAllCityByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert( string cityName)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertNewCity(cityName); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string cityName ,int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateNewCity(cityName ,id); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
