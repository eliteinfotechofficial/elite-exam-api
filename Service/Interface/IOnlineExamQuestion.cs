﻿using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOnlineExamQuestion
    {
        Task<dynamic> OnlineExam(OnlineExamQuestion O);
    }
}
