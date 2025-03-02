using GestionTareas.Api.Models;
using Serilog;
using Microsoft.Data.Sqlite;
using System.Xml.Linq;
using GestionTareas.Api.EntityModels;
using GestionTareas.Api.Models.Request;


namespace GestionTareas.Api.Infrastructure
{
    public class DbContext
    {
        private RptaGeneral _rptaGeneral;

        public DbContext(RptaGeneral rptaGeneral)
        {
            _rptaGeneral = rptaGeneral;

            _rptaGeneral.code = 0;
            _rptaGeneral.message = null;
            _rptaGeneral.data = null;
            _rptaGeneral.objectResponse = null;
        }
        public void CreateDatabase()
        {
            try
            {
                Log.Information("Start method: DbContext-CreateDatabase");

                //Create database demo in memory with table task

                using (var connection = new SqliteConnection("Data Source=:memory:"))
                {
                    SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @"create table task (id,name varchar(100))";

                    command.ExecuteReader();

                    int count = 10; 
                    for(int i = 1; i<= count; i++)
                    {
                        var commandInsert = connection.CreateCommand();
                        commandInsert.CommandText = @"insert into task(id,name) values("+i+",'Task "+i+"')";
                        commandInsert.ExecuteReader();
                    }

                }

            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                _rptaGeneral.code = 500;
                _rptaGeneral.message = ex.Message;
                _rptaGeneral.data = ex.ToString();
                
            }
        }

        public RptaGeneral Create(TaskCreateRequestModel taskCreateModel)
        {
            try
            {
                //Method create task in table memory

                Log.Information("Start method: DbContext-Create");

                using (var connection = new SqliteConnection("Data Source=:memory:"))
                {
                    SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                    connection.Open();

                    //Create table
                    var command = connection.CreateCommand();
                    
                    command.CommandText = @"create table task (id,name varchar(100))";
                    command.ExecuteReader();

                    //Insert the new task

                    var randomNumber = new Random().Next(1, 99);
                    
                    var command2 = connection.CreateCommand();
                    command2.CommandText = @"insert into task(id,name) values(" + randomNumber + ",'"+ taskCreateModel .name+ "')";
                    command2.ExecuteReader();
                   
                    _rptaGeneral.code = 200;
                    _rptaGeneral.message = "Tarea creada con éxito";
                    _rptaGeneral.data = "El -ID- de la nueva tarea es: " + randomNumber;

                }

                return _rptaGeneral;
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                _rptaGeneral.code = 500;
                _rptaGeneral.message = ex.Message;
                _rptaGeneral.data = ex.ToString();
                return _rptaGeneral;
            }
            
        }
        public RptaGeneral Select()
        {
            try
            {
                //Method get all of list table task

                Log.Information("Start method: DbContext-Select");

                using (var connection = new SqliteConnection("Data Source=:memory:"))
                {
                    SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());

                    connection.Open();

                    //Create table
                    var command = connection.CreateCommand();
                    command.CommandText = @"create table task (id,name varchar(100))";

                    command.ExecuteReader();

                    int count = 10;
                    for (int i = 1; i <= count; i++)
                    {
                        command = connection.CreateCommand();
                        command.CommandText = @"insert into task(id,name) values(" + i + ",'Task " + i + "')";
                        command.ExecuteReader();
                    }

                    command = connection.CreateCommand();
                    command.CommandText = @"select * from task";
 
                    using (var reader = command.ExecuteReader())
                    {
                        List<TaskModel> listTaks = new List<TaskModel>();

                        while (reader.Read())
                        {
                            TaskModel newTask = new TaskModel();
                            newTask.id = reader.GetInt32(0);
                            newTask.name = reader.GetString(1);

                            listTaks.Add(newTask);
                        }

                        _rptaGeneral.code = 200;
                        _rptaGeneral.message = "Consulta con éxito!";
                        _rptaGeneral.objectResponse = listTaks;
                    }

                }

                return _rptaGeneral;

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                _rptaGeneral.code = 500;
                _rptaGeneral.message = ex.Message;
                _rptaGeneral.data = ex.ToString();
                return _rptaGeneral;
            }
        }
    }
}
