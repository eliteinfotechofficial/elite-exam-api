﻿using Dapper;
using Helper.Dapper;
using Models.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class LoginService:ILogin
    {
        public async Task<dynamic> Login(Login l) 
        {
            var res = new ResValues(); 
            {
                var sql = "sp_login"; 
                var parameters = new DynamicParameters(); 
                parameters.Add("@username", l.UserName);          
                parameters.Add("@password", l.Password);
                
                var data = await DbHelper.RunProc<dynamic>(sql, parameters); 
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.Values = data.ToList();
                    res.StatusCode = 200;
                    res.Message = "Success";
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.Values = null;
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;

                }
                else
                {
                    res.Values = null;
                    res.StatusCode = 400;
                    res.Message = "no data";

                }
            }
            return res;
        }

    }
}
