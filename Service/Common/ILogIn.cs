﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Common
{
    [ServiceContract]
    public interface ILogIn
    {
        [OperationContract]
        int LogIn(string username, string password);
    }
}