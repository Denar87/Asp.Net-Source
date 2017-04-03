using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.DAL
{
    public class BrandDAL
    {
        ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();
        internal int InsertStyle(LC_Brand _lcBrand)
        {
            try
            {
                _Context.LC_Brand.AddObject(_lcBrand);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateStyle(LC_Brand _lcBrand)
        {
            try
            {
                LC_Brand _brand = _Context.LC_Brand.FirstOrDefault(x => x.BrandId == _lcBrand.BrandId);
                _brand.BrandName = _lcBrand.BrandName;
                _brand.EditDate = DateTime.Now;
                _brand.EditUser = _lcBrand.EditUser;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Brand> LoadBrandList(string Ocode)
        {
            try
            {
                List<LC_Brand> _brand = (from st in _Context.LC_Brand
                                         where st.OCode == Ocode
                                         select st).OrderBy(x => x.BrandName).ToList();
                return _brand;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal LC_Brand GetBrandLById(int BeandId)
        {
            try
            {
                return (from br in _Context.LC_Brand
                        where br.BrandId == BeandId
                        select br).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}