﻿using Core.DataAccess;
using Core.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface InterfaceCartItemDAL : InterfaceEntityRepository<CartItem>
    {
    }
}
