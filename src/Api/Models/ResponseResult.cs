﻿using Entity;

namespace Api.Models
{
    public class ResponseResult
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<Employee> Data { get; set; }
    }

    public enum ErrorCode
    {
        Success = 0,
        Failed = 1 
    }
}
