﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTask.ViewModels
{
    public class Result<T>
    {
        public bool Success { get; set; }

        public T ResponseObject { get; set; }

        public string ResponseMessage { get; set; }

        public Result(bool Success)
        {
            this.Success = Success;
        }
    }
}
