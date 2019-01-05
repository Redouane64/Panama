﻿using dev.Entities.Models;
using Panama.Commands;
using Panama.Entities;
using Panama.Sql;
using System.Collections.Generic;

namespace dev.Business.Validators
{
    public class UserExist : IValidation
    {
        private IQuery _query;
        public UserExist(IQuery query)
        {
            _query = query;
        }
        public bool IsValid(List<IModel> data)
        {
            var models = data.DataGet<User>();
            if (models == null)
                return false;

            foreach (var user in models)
                if (_query.Exist<User>("select * from [User] where ID = @ID", new { user.ID }))
                    return true;
            
            return false;
        }

        public string Message() => "Username/password invalid.";
    }
}
