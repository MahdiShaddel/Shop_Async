using Shop.DTOs.Vander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public class ServicesResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;

        public static implicit operator ServicesResponse<T>(ServicesResponse<List<VanderListDTO>> v)
        {
            throw new NotImplementedException();
        }
    }
}
