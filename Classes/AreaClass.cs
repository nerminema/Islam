﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
   public class AreaClass
    {
        public List<usp_SelectAllArea_Result> SelectAll()
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllArea().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }



        public List<usp_SelectAllAreaByID_Result> SelectAll(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllAreaByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAreaByCityID_Result> SelectAllByCity(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAreaByCityID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_DeleteAllAreaByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert(string AreaName , int cityID)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertNewArea(AreaName , cityID); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string AreaName, int id, int cityID)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateNewArea(AreaName, cityID, id ); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
