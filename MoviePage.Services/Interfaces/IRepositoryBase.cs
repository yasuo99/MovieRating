﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services.Interfaces
{
    public interface IRepositoryBase<TModel>
    {
        List<TModel> GetAll();

    }
}