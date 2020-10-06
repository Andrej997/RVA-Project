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

        [OperationContract]
        string AddTreningAdmin(int adminId, Trening trening);

        [OperationContract]
        string AddTreningVezbac(int vezbacId, Trening trening);

        [OperationContract]
        string DeleteTrening(Admin admin, Trening trening);

        [OperationContract]
        string DeleteTreningV(Vezbac vezbac, Trening trening);

        [OperationContract]
        List<Trener> GetTrenere();

        [OperationContract]
        List<Trening> GetTreninge(Admin admin);

        [OperationContract]
        List<Trening> GetTreningeV(Vezbac vezbac);

        [OperationContract]
        string Undo();

        [OperationContract]
        string Redo();

        [OperationContract]
        string CreateTrener(Trener trener);

        [OperationContract]
        string ChangeTrener(Trener trener);

        [OperationContract]
        string DeleteTrener(int id);

        [OperationContract]
        string ChangeUserA(Admin admin);

        [OperationContract]
        string ChangeUserV(Vezbac vezbac);

        [OperationContract]
        string ChangeUserT(Trener trener);

        [OperationContract]
        string SearchUser(string type, string input);
    }
}
