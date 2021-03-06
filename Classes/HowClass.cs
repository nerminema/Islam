﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
  public  class HowClass
    {
        public List<usp_SelectAllHowDidYouKnowUS_Result> SelectAll()
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllHowDidYouKnowUS().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllHowDidYouKnowUSByID_Result> SelectAll(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllHowDidYouKnowUSByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_DeleteAllHowDidYouKnowUSByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert(string HowDidYouKnowUSByIDName)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertNewHowDidYouKnowUS(HowDidYouKnowUSByIDName ,1); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Update(string HowDidYouKnowUSByIDName, int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateNewHowDidYouKnowUS(HowDidYouKnowUSByIDName, id); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
