using System;
using System.Collections.Generic;
using PIPOC_WMDB.Models;

namespace PIPOC_WMDB.IRepository
{
    public interface IUserRespository
    {
        Users Save(Users user);
        Users Get(string userId);
        List<Users> Gets();
        string Delete(string userId);
    }
}

