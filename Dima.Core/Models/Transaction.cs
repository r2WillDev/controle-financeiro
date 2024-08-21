using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Core.Enums;

namespace Dima.Core.Models
{

    public class Transaction //entrada e saida
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? PaidOrRecievedAt { get; set; }

        public ETransactionType Type { get; set; } = ETransactionType.withdraw;
        public decimal Amount { get; set; }

        public long CategoryId { get; set; }
        public Category category { get; set; } = null!;

        public string UserId { get; set; } = string.Empty;
    }
}