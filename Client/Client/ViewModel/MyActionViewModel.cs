using Client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class MyActionViewModel : BindableBase
    {
        public static ObservableCollection<MyAction> MyActions { get; set; }
        public MyActionViewModel()
        {
            MyActions = new ObservableCollection<MyAction>();
            if (!InternalData.Data.IsLoggedIn())
                Load();
        }

        private void Load()
        {
            string filename = @"D:\FAX\8.SEMESTAR\RVA\RVA-Project\Service\Service\bin\Debug\log.txt";
            while (IsFileReady(filename)) 
            {
                Read(filename);
                break;
            }
        }

        private static bool IsFileReady(string filename)
        {
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Read(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var stringData = line.Split('-');
                    if (stringData.Length == 3)
                    {
                        var second = stringData[1].Split(',');
                        var id = second[0].Split('=')[1];
                        if (InternalData.Data.ulogovanaOsova.ID != Int32.Parse(id))
                            continue;
                        var role = second[1].Split('=')[1].Split(')')[0];
                        if (InternalData.Data.ulogovanaOsova.Role != Int32.Parse(role))
                            continue;
                        MyAction myAction = new MyAction()
                        {
                            Timestamp = stringData[0],
                            Message = stringData[2]
                        };
                        MyActions.Add(myAction);
                    }
                }
            }
        }
    }
}
