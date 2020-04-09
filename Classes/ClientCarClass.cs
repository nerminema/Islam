using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
  public  class ClientCarClass
    {
        public List<usp_SelectAllClient_Cars_Result> SelectAll()
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllClient_Cars().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllClient_CarsByID_Result> SelectAll(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllClient_CarsByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectClientCarByClient_Result> SelectAllByCar(int Modelid)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectClientCarByClient(Modelid).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_DeleteAllClient_CarsByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
      
        public void Insert(int cLientID,int  carid ,string carno ,int  colorid ,string km,string cc , string v)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertNewClient_Car(cLientID, carid , carno , colorid , km , cc , v); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(int cLientID, int carid, string carno, int colorid, string km, int id, string cc, string v)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateNewClient_Car(cLientID, carid, carno, colorid, km, id ,cc , v); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
