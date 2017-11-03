using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Models.Interface;
using System.Configuration;

namespace SCMS.Datas
{
    public class SCMSFactory
    {
        public static ISCMS Create()
        {
            try
            {
                string mode = ConfigurationSettings.AppSettings["Mode"].ToString();
                switch (mode)
                {
                    case "Mock":
                        return new SCMSRepositoryMock();
                    default:
                        return new SCMSRepositoryEF();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
