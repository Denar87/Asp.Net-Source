using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class ApplicableDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int SaveApplicable(List<HRM_Applicable_PersonalStatus> _applicable)
        {
           
            try
            {
                if (_applicable.Count() > 0)
                {
                    foreach (HRM_Applicable_PersonalStatus aitem in _applicable)
                    {
                        bool status = false;
                        HRM_PersonalInformations _personal = _context.HRM_PersonalInformations.FirstOrDefault(x => x.EID == aitem.EID);
                        if (_personal != null)
                        {
                            _personal.Attendance_Bouns = aitem.Attendance_Bouns;
                            _personal.Late_Applicable = aitem.Late_Applicable;
                            _personal.Absence_Applicable = aitem.Absence_Applicable;
                            _personal.Tax_Applicable = aitem.Tax_Applicable;
                            _personal.PF_Applicable = aitem.PF_Applicable;
                            _personal.OTApplicable = aitem.OT_Applicable;
                            //_personal.On_Amount = aitem.On_Amount;
                            _context.SaveChanges();
                            status = true;
                        }


                        if (status == true)
                        {
                            _context.HRM_Applicable_PersonalStatus.AddObject(aitem);
                            _context.SaveChanges();


                        }
                    }
                    _context.SaveChanges();

                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        

        }
    }
}