using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityModel;

using System.Diagnostics;
using ERPSSL.INV;

namespace ERPSSL.INV.DAL
{
    public class ERPRepository<T>  where T:class
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();


        //public virtual int Insert(T entity)
        //{
        //    using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
        //    {
        //        try
        //        {
        //            ctx.Set<T>().Add(entity);
        //            ctx.SaveChanges
        //                ();
        //            return 1;
        //        }
        //        catch (DbEntityValidationException dbEx)
        //        {
        //            foreach (var validationErrors in dbEx.EntityValidationErrors)
        //            {
        //                foreach (var validationError in validationErrors.ValidationErrors)
        //                {
        //                    Trace.Write("Property: {0} Error: {1}" + validationError.PropertyName, validationError.ErrorMessage);
                            
        //                }
        //            }
        //            throw dbEx;
        //        }
        //        catch (Exception ex) 
        //        {

        //            throw ex;
        //        }
        //    }
            
        //}



        //public virtual List<T> GetAll()
        //{
        //    using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
        //    {
        //        try
        //        {
        //           // ctx.Configuration.ProxyCreationEnabled = false;
        //            var list = ctx.Set<T>().ToList();
        //            return list;
                    
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }

        //}





        //public virtual T SelectByID(int id)
        //{


        //    using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
        //    {
        //        try
        //        {
                    
        //            return  ctx.Set<T>().Find(Convert.ToInt32(id));
                    
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }

             
        //}

      
        //public virtual int Update(T obj)
        //{


        //    using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
        //    {
        //        try
        //        {
        //            ctx.Set<T>().Attach(obj);
        //            ctx.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        //            ctx.SaveChanges();
        //            return 1;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }            
            
        //}

        //public int Delete(T obj)
        //{


        //    using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
        //    {
        //        try
        //        {
        //           // T existing = ctx.Set<T>().Find(id);
        //            ctx.Set<T>().Attach(obj);    
        //           ctx.Set<T>().Remove(obj);     
                    
        //            ctx.SaveChanges();
        //            return 1;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }            
            
            
        //}

      



    }
}
