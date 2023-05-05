﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace ECourse.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; private set; }

        public static Response<T> Success(T data, int statusCode) 
        {
            return new Response<T> 
            { 
                Data = data,
                StatusCode = statusCode,
                IsSuccessful=true
            };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> 
            {
                StatusCode = statusCode, 
                IsSuccessful = true 
            };
        }

        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }


        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T>
            {
                Errors = new List<string>() {error},
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
    }
}
