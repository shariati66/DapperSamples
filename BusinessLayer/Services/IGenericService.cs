﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IGenericService<T>
    {
        //Task<List<T>> GetAll();
        List<T> GetAll();
       
    }
}
