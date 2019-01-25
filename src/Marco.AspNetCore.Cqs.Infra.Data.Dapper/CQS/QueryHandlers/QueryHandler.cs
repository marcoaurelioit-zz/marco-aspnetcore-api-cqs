namespace Marco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.QueryHandlers
{
    public abstract class @QueryHandler<TContext>
    {
        protected TContext dbContext;
        public QueryHandler(TContext dbContext) => this.dbContext = dbContext;
    }
}