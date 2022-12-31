using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreInterceptorSample
{
    public class ExampleTransactionInterceptor
         : DbTransactionInterceptor
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger logger;

        public ExampleTransactionInterceptor(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory.CreateLogger<ExampleTransactionInterceptor>();
        }

        public override ValueTask<DbTransaction> TransactionStartedAsync(DbConnection connection, TransactionEndEventData eventData, DbTransaction result, CancellationToken cancellationToken = default)
        {
            this.logger.LogInformation($"[{nameof(ExampleTransactionInterceptor)}] Transaction Started.");
            return base.TransactionStartedAsync(connection, eventData, result, cancellationToken);
        }
        public override Task TransactionCommittedAsync(DbTransaction transaction, TransactionEndEventData eventData, CancellationToken cancellationToken = default)
        {
            this.logger.LogInformation($"[{nameof(ExampleTransactionInterceptor)}] Transaction Committed.");
            return base.TransactionCommittedAsync(transaction, eventData, cancellationToken);
        }
    }
}
