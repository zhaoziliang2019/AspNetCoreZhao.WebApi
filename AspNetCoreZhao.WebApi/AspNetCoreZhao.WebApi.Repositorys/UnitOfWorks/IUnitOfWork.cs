using SqlSugar;

namespace AspNetCoreZhao.WebApi.Repositorys.UnitOfWorks
{
    public interface IUnitOfWork
    {
        SqlSugarClient GetDbClient();

        void BeginTran();

        void CommitTran();
        void RollbackTran();
    }
}
