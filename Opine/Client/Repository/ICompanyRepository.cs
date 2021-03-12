﻿using Opine.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opine.Client.Repository
{
    public interface ICompanyRepository
    {
        Task CreateCompany(Company company);
        Task<List<Company>> GetCompanies();
    }
}