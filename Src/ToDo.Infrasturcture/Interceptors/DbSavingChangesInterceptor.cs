

using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using ToDo.Infrasturcture.Extensions;

namespace ToDo.Infrasturcture.Interceptors;


    internal class DBSavingChangesInterceptor : SaveChangesInterceptor
    {
        private readonly ILogger<DBSavingChangesInterceptor> _logger;

        public DBSavingChangesInterceptor(ILogger<DBSavingChangesInterceptor> logger)
        {
            _logger = logger;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            var dbContext = eventData.Context;

            if (dbContext is null)
            {
                _logger.LogWarning("DbContext is null during SavingChangesAsync.");
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            try
            {
                dbContext.UpdateAuditableEntities();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating entities in SavingChangesAsync.");
                throw;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            var dbContext = eventData.Context;

            if (dbContext is null)
            {
                _logger.LogWarning("DbContext is null during SavingChanges.");
                return base.SavingChanges(eventData, result);
            }

            try
            {
                dbContext.UpdateAuditableEntities();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating entities in SavingChanges.");
                throw;
            }

            return base.SavingChanges(eventData, result);
        }
    }

