using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RepositoryResponse<ReturnType>
    {
        public ReturnType Result { get; set; }
        public Exception Ex { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public RepositoryResponse(ReturnType result, bool success = true) 
        {
            this.Result = result;
            this.Success = success;
        }
        public RepositoryResponse(string message, bool success = false)
        {
            this.Message = message;
            this.Success = success;
        }

        public RepositoryResponse(Exception ex, bool success = false)
        {
            this.Ex = ex;
            this.Success = success;
        }
    }
}
