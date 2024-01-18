using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.BL;

public class GeneralResponse
{
    public string Message { get; set; } = string.Empty;
    public GeneralResponse(string msg)
    {
        Message = msg;
    }
}
