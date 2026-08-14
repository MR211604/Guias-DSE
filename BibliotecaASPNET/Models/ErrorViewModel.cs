using System.Diagnostics.CodeAnalysis;

namespace BibliotecaASPNET.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        [MemberNotNullWhen(true, nameof(RequestId))]
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
