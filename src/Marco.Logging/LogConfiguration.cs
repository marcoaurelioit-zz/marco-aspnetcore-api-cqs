using System.ComponentModel.DataAnnotations;

namespace Marco.Logging
{
    public class LogConfiguration
    {
        [Required]
        public LogType? LogType { get; set; }

        public LogWriteType LogWriteType { get; set; } = LogWriteType.Console;
    }
}