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
            MyStatusCode = MyStatusCode.OK
        };
    }

    public static ResponseResult OK(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Success!",
            MyStatusCode = MyStatusCode.OK
        };
    }

    public static ResponseResult OK()
    {
        return new ResponseResult
        {
            Message = "Success!",
            MyStatusCode = MyStatusCode.OK
        };
    }

    public static ResponseResult Error(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Failed",
            MyStatusCode = MyStatusCode.ERROR
        };
    }

    public static ResponseResult NotFound(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Not found!",
            MyStatusCode = MyStatusCode.NOT_FOUND
        };
    }

    public static ResponseResult Exists(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "It allready exists!",
            MyStatusCode = MyStatusCode.EXISTS
        };
    }
}
