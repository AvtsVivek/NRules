using System;

namespace NR1003020DynamicNRulesWithServiceAddedAsFact.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
