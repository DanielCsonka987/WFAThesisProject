﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public class ErrorServiceCreateDataList : Exception
    {
        private string message;
        public ErrorServiceCreateDataList(string message) :base(message)
        {
            this.message = message;
        }
    }
}
