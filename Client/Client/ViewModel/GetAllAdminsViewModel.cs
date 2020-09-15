using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class GetAllAdminsViewModel : BindableBase
    {
        public GetAllAdminsViewModel()
        {
            var admins = InternalData.Data.service.GetAllAdmins();
        }
    }
}
