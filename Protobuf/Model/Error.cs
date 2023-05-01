using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    internal class Error
    {
        internal Error(string? errorId, string? errorMessage)
        {
            ErrorId = errorId;
            ErrorMessage = errorMessage;
        }

        internal string? ErrorId { get; set; }
        internal string? ErrorMessage { get; set; }
    }
}
