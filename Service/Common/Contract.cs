using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Common
{
    public class Contract : IContract
    {
        private DBService service;
        private Proxy proxy;
        private LogInOut LogInOut;
        private CRUDUser CRUDUser;
        private CRUDTrening CRUDTrening;
        private UndoRedo undoRedo;

        public Contract()
        {
            service = new DBService();
            proxy = new Proxy(service);
            LogInOut = new LogInOut();
            CRUDUser = new CRUDUser();
            CRUDTrening = new CRUDTrening();
            undoRedo = new UndoRedo();
        }

        public string AddTreningAdmin(int adminId, Trening trening)
        {
            return CRUDTrening.AddTreningAdmin(adminId, proxy, trening);
        }

        public string AddTreningVezbac(int vezbacId, Trening trening)
        {
            return CRUDTrening.AddTreningVezbac(vezbacId, proxy, trening);
        }

        public string ChangeAdmin(Admin admin)
        {
            return CRUDUser.ChangeAdmin(admin, proxy);
        }

        public string ChangeVezbac(Vezbac vezbac)
        {
            return CRUDUser.ChangeVezbac(vezbac, proxy);
        }

        public string CreateAdmin(Admin admin)
        {
            return CRUDUser.CreateAdmin(admin, proxy);
        }

        public string CreateVezbac(Vezbac vezbac)
        {
            return CRUDUser.CreateVezbac(vezbac, proxy);
        }

        public string DeleteAdmin(Admin admin)
        {
            return CRUDUser.DeleteAdmin(admin, proxy);
        }

        public string DeleteTrening(Admin admin, Trening trening)
        {
            return CRUDTrening.DeleteTrening(admin, trening, proxy);
        }

        public string DeleteTreningV(Vezbac vezbac, Trening trening)
        {
            return CRUDTrening.DeleteTrening(vezbac, trening, proxy);
        }

        public string DeleteVezbac(Vezbac vezbac)
        {
            return CRUDUser.DeleteVezbac(vezbac, proxy);
        }

        public List<Admin> GetAllAdmins()
        {
            return CRUDUser.GetAllAdmins(proxy);
        }

        public List<Vezbac> GetAllVezbace()
        {
            return CRUDUser.GetAllVezbace(proxy);
        }

        public List<Trener> GetTrenere()
        {
            return CRUDTrening.GetTrenere(proxy);
        }

        public List<Trening> GetTreninge(Admin admin)
        {
            return CRUDTrening.GetTreninge(admin, proxy);
        }

        public List<Trening> GetTreningeV(Vezbac vezbac)
        {
            return CRUDTrening.GetTreninge(vezbac, proxy);
        }

        public Admin LogInAdmin(LoginUser user)
        {
            return LogInOut.LoginAdmin(user, proxy);
        }

        public Vezbac LogInVezbac(LoginUser user)
        {
            return LogInOut.LoginVezbac(user, proxy);
        }

        public void LogOut(string username)
        {
            LogInOut.Logout(username, proxy);
        }

        public string Redo()
        {
            return CRUDTrening.Redo();
        }

        public string Undo()
        {
            return CRUDTrening.Undo();
        }
    }
}
