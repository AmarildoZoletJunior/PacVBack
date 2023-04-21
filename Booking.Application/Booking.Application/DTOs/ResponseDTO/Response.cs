using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.DTOs.ResponseDTO
{
    public class Response<T> where T : class
    {
        public bool IsValid { get; set; }
        public T Data { get; set; }
        public List<MessageError> MessagesErrors { get; set; } = new List<MessageError>();

        public Response()
        {
            this.IsValid = true;
        }

        public void AddMessage(string title, string message)
        {
            this.IsValid = false;
            if (this.Data != null)
            {
                this.Data = null;
            }
            MessagesErrors.Add(new MessageError(title, message));
        }

        public void AddData(T data)
        {
            if (this.MessagesErrors.Count == 0)
            {
                this.Data = data;
                this.IsValid = true;
            }
        }

    }
}
