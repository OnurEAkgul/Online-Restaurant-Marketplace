﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Domains;
using DataAccess.EntityFramework;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderDAL:EntityRepository<Order,ApplicationDbContext>, InterfaceOrderDAL
    {
    }
}
