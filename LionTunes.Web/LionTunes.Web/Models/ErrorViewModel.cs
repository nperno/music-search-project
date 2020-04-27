using System;

namespace LionTunes.Web.Models
{   
    /// <summary>
    /// This ViewModel binds the Error info.
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
