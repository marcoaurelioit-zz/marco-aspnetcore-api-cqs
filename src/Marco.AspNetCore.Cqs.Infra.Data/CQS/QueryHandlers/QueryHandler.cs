namespace Marco.AspNetCore.Cqs.Infra.Data.CQS.QueryHandlers
{
    public abstract class @QueryHandler<TContext>
    {
        protected TContext _dbContext;

        public QueryHandler(TContext dbContext) =>
            _dbContext = dbContext;

        public QueryHandler() { }
    }
}