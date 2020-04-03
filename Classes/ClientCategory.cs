using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
   public class ClientCategoryClass
    {
        public List<usp_SelectAllClient_Category_Result> SelectAll()
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_SelectAllClient_Category().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllClient_CategoryByID_Result> SelectAll(int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_SelectAllClient_CategoryByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_DeleteAllClient_CategoryByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert(string Client_CategoryName)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_InsertNewClient_Category(Client_CategoryName); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string Client_CategoryName, int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_UpdateNewClient_Category(Client_CategoryName, id); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
