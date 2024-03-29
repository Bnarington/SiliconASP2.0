using Infrastructure.Models;
using System.Net.NetworkInformation;

namespace Infrastructure.Factories;

public class ResponseFactory
{
    public static ResponseResult OK(object obj, string? message = null)
    {
        return new ResponseResult
        {
            ContentResult = obj,
            Message = message ?? "Success!",
            StatusCode = StatusCode.OK
        };
    }

    public static ResponseResult OK(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Success!",
            StatusCode = StatusCode.OK
        };
    }

    public static ResponseResult OK()
    {
        return new ResponseResult
        {
            Message = "Success!",
            StatusCode = StatusCode.OK
        };
    }

    public static ResponseResult Error(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Failed",
            StatusCode = StatusCode.ERROR
        };
    }

    public static ResponseResult NotFound(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Not found!",
            StatusCode = StatusCode.NOT_FOUND
        };
    }

    public static ResponseResult Exists(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "It allready exists!",
            StatusCode = StatusCode.EXISTS
        };
    }
}
