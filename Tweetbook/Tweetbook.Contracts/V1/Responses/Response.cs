﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tweetbook.Contracts.V1.Responses
{
   public class Response<T>
    {
        public Response() {}

        public Response(T response)
        {
            Data = response;
        }

        public T Data { get; set; }
    }
}