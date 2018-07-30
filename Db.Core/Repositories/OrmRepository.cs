using Contracts.Interfaces;
using Dapper;
using Dapper.FastCrud;
using Dapper.FastCrud.Configuration.StatementOptions.Builders;
using Db.Core.Utilites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Db.Core.Repositories
{
    public interface IOrmRepository<T>
    {
        T Get(T obj);
        IEnumerable<T> GetAll(Func<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<T>, IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<T>> statement = null);
        bool Delete(T obj);
        T Save(T obj);
        int ExecuteStoredProcedure(string storedProcedureName, DynamicParameters p);
    }

    public abstract class OrmRepository<T> : IOrmRepository<T>
    {
        protected IDataSettings _dataSettings { get; }
        protected IUnitOfWork _unitOfWork { get; }
        protected OrmRepository(IDataSettings dataSettings)
        {
            _dataSettings = dataSettings;
            _unitOfWork = new UnitOfWork(dataSettings);

        }

        public T Get(T obj)
        {
            return GetCurrentConnection().Get(obj, statement => statement.AttachToTransaction(GetCurrentTransaction()));
        }

        public IEnumerable<T> GetAll(Func<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<T>, IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<T>> statement = null)
        {
            if (statement == null)
            {
                statement = s => s;
            }

            DbConnection conn = GetCurrentConnection();
            DbTransaction transaction = GetCurrentTransaction();
            return conn.Find<T>(s => statement(transaction != null ? s.AttachToTransaction(transaction) : s));
        }

        public bool Delete(T obj)
        {
            return GetCurrentConnection().Delete(obj, s => s.AttachToTransaction(GetCurrentTransaction()));
        }

        public T Save(T obj)
        {
            bool shouldInsert = CheckForInsert(obj);
            _unitOfWork.BeginTransaction();
            try
            {
                DbConnection conn = GetCurrentConnection();
                if (shouldInsert)
                {
                    conn.Insert(obj, statement => statement.AttachToTransaction(GetCurrentTransaction()));
                }
                else
                {
                    conn.Update(obj, statement => statement.AttachToTransaction(GetCurrentTransaction()));
                }
                _unitOfWork.Commit();
                return obj;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public int ExecuteStoredProcedure(string storedProcedureName, DynamicParameters p)
        {
            var conn = GetCurrentConnection();
            return conn.Execute(storedProcedureName, p, commandType: CommandType.StoredProcedure, transaction: GetCurrentTransaction());
        }

        protected bool CheckForInsert(T obj)
        {
            return ((IId<int>)obj).Id == 0;
        }

        protected DbConnection GetCurrentConnection()
        {
            return _unitOfWork.GetDbConnection();
        }

        protected DbTransaction GetCurrentTransaction()
        {
            return _unitOfWork.GetDbTransaction();
        }
    }
}
