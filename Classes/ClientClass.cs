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
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllClients().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllClientsCar_Result> SelectAllWithCarsData()
        {
            ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllClientsCar().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllClientsByID_Result> SelectAll(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllClientsByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_DeleteAllClientsByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public int? Max()
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectMaxClientID().First(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Insert(string client_Name, string client_Mobil, string client_WhatusApp, int? clientAreaID, int? client_CatID, int? howDidYouKnowus, int? branchID)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertNewClient(client_Name, client_Mobil, client_WhatusApp, clientAreaID, client_CatID, howDidYouKnowus, branchID); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string client_Name, string client_Mobil, string client_WhatusApp, int? clientAreaID, int? client_CatID, int? howDidYouKnowus, int? branchID, int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateNewClient(client_Name, client_Mobil, client_WhatusApp, clientAreaID, client_CatID, howDidYouKnowus, branchID, id); }
            catch { }
            finally { db.Dispose(); }
        }
        #region Filter 
        public List<usp_SelectAllClientsByName_Result> SearchByName(string name)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllClientsByName(name).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllClientsByMobil_Result> SearchByMobil(string mobil)
        {
            ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllClientsByMobil(mobil).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByAreaID_Result> SearchByArea(int area)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_FilterAllClientsByAreaID(area).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsBybranchID_Result> SearchByBranch(int area)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_FilterAllClientsBybranchID(area).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByCatID_Result> SearchBycat(int area)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_FilterAllClientsByCatID(area).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByCityID_Result> SearchByCity(int area)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_FilterAllClientsByCityID(area).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByHOWID_Result> SearchByHowID(int how)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_FilterAllClientsByHOWID(how).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsBybRANDID_Result> SearchByBrandID(int how)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_FilterAllClientsBybRANDID(how).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByCarID_Result> SearchByCarID(int how)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_FilterAllClientsByCarID(how).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_FilterAllClientsByID_Result> SearchByID(int how)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_FilterAllClientsByID(how).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        #endregion
    }
}
