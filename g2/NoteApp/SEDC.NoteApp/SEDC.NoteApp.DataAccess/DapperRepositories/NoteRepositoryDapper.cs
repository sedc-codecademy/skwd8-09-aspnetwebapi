using Dapper;
using Dapper.Contrib.Extensions;
using SEDC.NoteApp.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SEDC.NoteApp.DataAccess.DapperRepositories
{
	public class NoteRepositoryDapper : IRepository<NoteDTO>
	{
		private readonly string _connectionString;
		public NoteRepositoryDapper(string connectionString)
		{
			_connectionString = connectionString;
		}

		public void Add(NoteDTO entity)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				connection.Insert(entity);
			}
		}

		public void Delete(NoteDTO entity)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				connection.Delete(entity);
			}
		}

		public IEnumerable<NoteDTO> GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				List<NoteDTO> result = connection.Query<NoteDTO>("SELECT * FROM Notes").ToList();

				return result;
			}
		}

        public NoteDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(NoteDTO update)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				connection.Update(update);
			}
		}
	}
}
