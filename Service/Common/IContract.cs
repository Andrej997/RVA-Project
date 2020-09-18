using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Common
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        Admin LogInAdmin(LoginUser user);

        [OperationContract]
        Vezbac LogInVezbac(LoginUser user);

        [OperationContract]
        void LogOut(string username);

        [OperationContract]
        string CreateAdmin(Admin admin);

        [OperationContract]
        string CreateVezbac(Vezbac vezbac);

        [OperationContract]
        List<Admin> GetAllAdmins();

        [OperationContract]
        List<Vezbac> GetAllVezbace();

        [OperationContract]
        string DeleteAdmin(Admin admin);

        [OperationContract]
        string DeleteVezbac(Vezbac vezbac);

        [OperationContract]
        string ChangeAdmin(Admin admin);

        [OperationContract]
        string ChangeVezbac(Vezbac vezbac);
    }
}
