using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using practiceClimbingShop.Models;

namespace practiceClimbingShop.Repositories
{
    public class RopesRepository
    {
        private IDbConnection _db;
        public RopesRepository(IDbConnection db)
        {
            _db = db;
        }

        //CRUD
        //Get
        public IEnumerable<Rope> GetAll()
        {
            return _db.Query<Rope>("SELECT * FROM ropes;");
        }

        //Get by id
        public Rope GetById(int id)
        {
            return _db.Query<Rope>("SELECT * FROM ropes WHERE id = @id;", new { id }).FirstOrDefault();
        }

        //Create
        public Rope Create(Rope rope)
        {
            try
            {
                int id = _db.ExecuteScalar<int>(@"INSERT INTO ropes
            (name, description, price)
            VALUES (@Name, @Description, @Price);
            SELECT LAST_INSERT_ID();", rope);
                rope.Id = id;
                return rope;
            }
            catch (SqlException err)
            {
                throw new System.Exception("A valid rope must have a name, description, and price.", err);
            }
        }

        //Update
        public Rope Update(Rope rope)
        {
            try
            {
            _db.Execute(@"UPDATE ropes
            SET name = @Name, description = @Description, price = @Price
            WHERE id = @Id;", rope);
            return rope;
            }
            catch (SqlException err)
            {
                throw new System.Exception("Cannot update the rope without having all the appropriate information.", err);
            }
        }

        //Delete
        public Rope Delete(Rope rope)
        {
            try
            {
                _db.Execute("DELETE FROM ropes WHERE id = @Id", rope);
                return rope;
            }
            catch (SqlException err)
            {
                throw new System.Exception("Delete unsuccessfull.", err);
            }
        }
    }
}