using System;

namespace SWRELS.Domain
{
    public class ErrorMsg
    {
        public virtual int Id { get; set; }
        public virtual string Message { get; set; }
        public virtual string ProgNotes { get; set; }
        public virtual DateTime DateTimeStamp { get; set; }
    }
}