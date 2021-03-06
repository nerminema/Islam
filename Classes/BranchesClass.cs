﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK_POWER.Classes
{
  public  class BranchesClass
    {
        public List<usp_SelectAllBranches_Result> SelectAll()
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllBranches().ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectAllBranchesByID_Result> SelectAll(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectAllBranchesByID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public List<usp_SelectBranchesByCityID_Result> SelectAllByCity(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { return db.usp_SelectBranchesByCityID(id).ToList(); }
            catch { return null; }
            finally { db.Dispose(); }
        }
        public void Delete(int id)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_DeleteAllBranchesByID(id); }
            catch { }
            finally { db.Dispose(); }
        }
        public void Insert(string BranchesName, int cityID)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_InsertNewBranches(BranchesName, cityID); }
            catch (Exception ex) 
            { }
            finally { db.Dispose(); }
        }
        public void Update(string BranchesName, int id, int cityID)
        {
             ALKPowerEntities db = new ALKPowerEntities();
            try { db.usp_UpdateNewBranches(BranchesName, cityID, id); }
            catch { }
            finally { db.Dispose(); }
        }
    }
}
