﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
  public  class ColorsClass
    {
        public List<usp_SelectAllColors_Result> SelectAll()
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllColors().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllColorsByID_Result> SelectAll(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllColorsByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_DeleteAllColorsByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert(string ColorsName)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertNewColors(ColorsName ,1); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string ColorsName, int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateNewColors(ColorsName, id); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
