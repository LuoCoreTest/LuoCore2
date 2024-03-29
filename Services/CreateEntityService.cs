﻿using DataTransferModels.CreateEntity.Request;
using IRepository;
using IServices;
using System;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using ViewModels.UserBasis.Request;

namespace Services
{
    public class CreateEntityService : SqlSugarRepository<ICreateEntityRepository>, ICreateEntityService
    {
        public CreateEntityService(ISqlSugarFactory factory, ICreateEntityRepository repository) : base(factory, repository)
        {
        }

        public Task<bool> CreateDefaultValue(RequestCreateEntityVm req) 
        {
            return Task.FromResult(_REPOSITORY.CreateDefaultValue(new CreateEntityDto() { DirectoryPath = req.DirectoryPath, NameSpace = req.NameSpace }));
        }

        public Task<bool> CreateAttribute(RequestCreateEntityVm req)
        {
            return Task.FromResult(_REPOSITORY.CreateAttribute(new CreateEntityDto() { DirectoryPath = req.DirectoryPath, NameSpace = req.NameSpace }));
        }
    }
}
