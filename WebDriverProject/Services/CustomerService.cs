using NLog;
using Npgsql;
using System.Data;
using WebDriverProject.Models;

namespace WebDriverProject.Services;

public class CustomerService
{
    private NpgsqlConnection _connection;
    private Logger _logger = LogManager.GetCurrentClassLogger();

    public CustomerService(NpgsqlConnection connection)
    {
        _connection = connection;
    }


    public List<Customers> GetAllCustomers()
    {
        var customersList = new List<Customers>();


        var cmd = new NpgsqlCommand("SELECT * FROM public.customer", _connection);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var customer = new Customers()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                LastName = reader.GetString(reader.GetOrdinal("lastname")),
                Email = reader.GetString(reader.GetOrdinal("email")),
                Age = reader.GetInt32(reader.GetOrdinal("age"))
            };

            customersList.Add(customer);
            _logger.Info(customer.ToString);
        }

        return customersList;
    }

    public Customers AddCustomerAndReturnModel(Customers customers)
    {
        var sqlQuery = $"INSERT INTO public.customer(firstname, lastname, email, age)" +
                       $"VALUES ('{customers.FirstName}', '{customers.LastName}', '{customers.Email}', '{customers.Age}');";
        _logger.Info(sqlQuery);
        var cmd = new NpgsqlCommand(sqlQuery, _connection);
        _logger.Info(cmd.ExecuteNonQuery());
        return GetCustomerByModel(customers);
    }

    public Customers? GetCustomerById(int id)
    {
        var cmd = new NpgsqlCommand($"SELECT *FROM public.customer WHERE id={id};", _connection);
        var reader = cmd.ExecuteReader();
        Customers? customer = null;
        while (reader.Read())
        {
            customer = new Customers()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                LastName = reader.GetString(reader.GetOrdinal("lastname")),
                Email = reader.GetString(reader.GetOrdinal("email")),
                Age = reader.GetInt32(reader.GetOrdinal("age"))
            };
            _logger.Info(customer.ToString);
        }

        return customer;
    }

    private Customers? GetCustomerByModel(Customers customers)
    {
        var sqlQuery = $"SELECT *FROM public.customer WHERE firstname='{customers.FirstName}' " +
                       $"AND lastname='{customers.LastName}'" +
                       $"AND age='{customers.Age}'" +
                       $"AND email='{customers.Email}';";

        _logger.Info(sqlQuery);
        var cmd = new NpgsqlCommand(sqlQuery, _connection);
        var reader = cmd.ExecuteReader();
        Customers? customer = null;
        while (reader.Read())
        {
            customer = new Customers()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                LastName = reader.GetString(reader.GetOrdinal("lastname")),
                Email = reader.GetString(reader.GetOrdinal("email")),
                Age = reader.GetInt32(reader.GetOrdinal("age"))
            };
            _logger.Info(customer.ToString);
        }

        return customer;
    }

    public int DeleteCustomerById(int id)
    {
        var cmd = new NpgsqlCommand($"DELETE FROM public.customer WHERE id={id};", _connection);
        return cmd.ExecuteNonQuery();
    }
}