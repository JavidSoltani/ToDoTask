using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTask.Application.Common;

public static class HashExtension
{
    public static string HashPassword(this string password)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = SHA1.HashData(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}
