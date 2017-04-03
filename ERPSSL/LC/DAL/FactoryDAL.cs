using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.DAL
{
    public class FactoryDAL
    {
        ERPSSL_LCEntities _Content = new ERPSSL_LCEntities();

        internal int InsertFactory(LC_Factory _lcFactory)
        {
            try
            {
                _Content.LC_Factory.AddObject(_lcFactory);
                _Content.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateFactory(LC_Factory _lcFactory)
        {
            try
            {
                LC_Factory _Factory = _Content.LC_Factory.FirstOrDefault(x => x.FactoryId == _lcFactory.FactoryId);

                _Factory.FactoryName = _lcFactory.FactoryName;
                _Factory.FactoryCode = _lcFactory.FactoryCode;
                _Factory.ContactPerson1 = _lcFactory.ContactPerson1;
                _Factory.CP1_Designation = _lcFactory.CP1_Designation;
                _Factory.CP1_ContactNumber = _lcFactory.CP1_ContactNumber;
                _Factory.CP1_Email = _lcFactory.CP1_Email;
                _Factory.ContactPerson2 = _lcFactory.ContactPerson2;
                _Factory.CP2_Designation = _lcFactory.CP2_Designation;
                _Factory.CP2_ContactNumber = _lcFactory.CP2_ContactNumber;
                _Factory.CP2_Email = _lcFactory.CP2_Email;
                _Factory.FactoryAddress = _lcFactory.FactoryAddress;
                _Factory.FactoryMobile = _lcFactory.FactoryMobile;
                _Factory.FactoryEmail = _lcFactory.FactoryEmail;
                _Factory.FactoryWeb = _lcFactory.FactoryWeb;
                _Factory.EditDate = DateTime.Now;
                _Factory.EditUser = _lcFactory.EditUser;
                _Content.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Factory> LoadFactoryList(string Ocode)
        {
            try
            {
                List<LC_Factory> _Factory = (from fq in _Content.LC_Factory
                                             where fq.OCode == Ocode
                                             select fq).OrderBy(x => x.FactoryName).ToList();
                return _Factory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal LC_Factory GetFactoryLById(int fqId)
        {
            try
            {
                return (from br in _Content.LC_Factory
                        where br.FactoryId == fqId
                        select br).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Factory> LoadFactoryListByName(string name)
        {
            try
            {
                using (var _context=new ERPSSL_LCEntities())
                {
                    return _context.LC_Factory.Where(x => x.FactoryName == name).ToList();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal List<LC_Factory> LoadFactoryListBySName(string Ocode, string F_Name)
        {
            try
            {
                List<LC_Factory> _Factory = (from fq in _Content.LC_Factory
                                             where fq.OCode == Ocode && fq.FactoryName==F_Name
                                             select fq).OrderBy(x => x.FactoryName).ToList();
                return _Factory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}