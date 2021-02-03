using servico.notificacao.Domain.Events;

namespace servico.notificacao.Domain.Exceptions
{
    public class ExceptionNotification : Event
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string ParamName { get; set; }
        public ExceptionNotification(string code, string message, string paramName)
        {
            Code = code;
            Message = message;
            ParamName = paramName;
        }
    }
}