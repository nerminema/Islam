using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
   public class OrderStatusClass
    {
        public List<usp_SelectAllStatus_Result> SelectAll()
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try
            { return db.usp_SelectAllStatus().ToList(); }
            catch{ return null; }
            finally{ db.Dispose(); }
        }
        public List<usp_SelectAllOrdersByID_Result> SelectAll(int id )
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try
            { return db.usp_SelectAllOrdersByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete (int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try{ db.usp_DeleteOrder(id); }
            catch{ }
            finally{ db.Dispose(); }
        }
        public void Update( string status ,int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateOrderStatus(status,id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert(string status)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertORderStus(status); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
