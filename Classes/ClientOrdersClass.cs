using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
   public  class ClientOrdersClass
    {
        public void UpdateNewOrder (int clientID ,int  orderStatusID ,DateTime  orderDate ,int  branchID ,decimal totalOrder ,decimal discount , decimal tax ,decimal finalOrder ,int  id)
        {
            ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateNewOrder(clientID , orderStatusID , orderDate , branchID , totalOrder , discount , tax , finalOrder , id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void InsertNewOrder(int clientID, int orderStatusID, DateTime orderDate, int branchID, decimal totalOrder, decimal discount, decimal tax, decimal finalOrder)
        {
            ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertNewOrder(clientID, orderStatusID, orderDate, branchID, totalOrder, discount, tax, finalOrder); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
