using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
   public class ClientClass
    {
        public List<usp_SelectAllClients_Result> SelectAll()
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_SelectAllClients().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllClientsByID_Result> SelectAll(int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_SelectAllClientsByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_DeleteAllClientsByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public int? Max()
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try {return db.usp_SelectMaxClientID().First(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Insert(string client_Name,string client_Mobil ,string client_WhatusApp ,int clientAreaID ,int client_CatID ,int howDidYouKnowus ,int branchID)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_InsertNewClient(client_Name , client_Mobil , client_WhatusApp ,clientAreaID , client_CatID , howDidYouKnowus , branchID); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string client_Name, string client_Mobil, string client_WhatusApp, int clientAreaID, int client_CatID, int howDidYouKnowus, int branchID, int id)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { db.usp_UpdateNewClient(client_Name, client_Mobil, client_WhatusApp, clientAreaID, client_CatID, howDidYouKnowus, branchID, id); }
            catch { }
            finally { db.Dispose(); }
        }
        #region Filter 
        public List<usp_SelectAllClientsByName_Result> SearchByName(string name )
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_SelectAllClientsByName(name).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByAreaID_Result> SearchByArea(int area)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_FilterAllClientsByAreaID(area).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsBybranchID_Result> SearchByBranch(int area)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_FilterAllClientsBybranchID(area).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByCatID_Result> SearchBycat(int area)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_FilterAllClientsByCatID(area).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByCityID_Result> SearchByCity(int area)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_FilterAllClientsByCityID(area).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByHOWID_Result> SearchByHowID(int how)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_FilterAllClientsByHOWID(how).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByID_Result> SearchByID(int how)
        {
            ALK_PowerEntities db = new ALK_PowerEntities();
            try { return db.usp_FilterAllClientsByID(how).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        #endregion
    }
}
