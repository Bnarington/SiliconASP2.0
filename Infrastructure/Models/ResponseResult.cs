﻿namespace Infrastructure.Models;

public enum MyStatusCode
{
    OK = 200,
    ERROR = 400,
    NOT_FOUND = 404,
    EXISTS = 409
}

public class ResponseResult
{
    public MyStatusCode MyStatusCode { get; set; }
    public object? ContentResult { get; set; }
    public string? Message { get; set; }
}


