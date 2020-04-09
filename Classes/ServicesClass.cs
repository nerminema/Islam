using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
   public class ServicesClass
    {
        public List<usp_SelectAllServices_Result> SelectAll()
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllServices().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllServicesByID_Result> SelectAll(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllServicesByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_DeleteAllServicesByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert(string ServicesName , decimal fees)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertNewServices(ServicesName , fees); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string ServicesName, int id, decimal fees)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateNewServices(ServicesName,fees, id ); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
