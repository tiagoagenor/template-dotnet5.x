using System;
using MediatR;

namespace servico.notificacao.Domain.Events
{
	public class Event : INotification
	{
		public DateTime Timestamp { get; set; }

		protected Event()
		{
			Timestamp = DateTime.Now;
		}
	}
}