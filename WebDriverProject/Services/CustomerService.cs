using Npgsql;
using NUnit.Framework.Internal;
using WebDriverProject.Models;

namespace WebDriverProject.Services;

public class CustomerService
{
    private readonly NpgsqlConnection _connection;

    public CustomerService(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public List<Customer> GetAllCustomers()
    {
        var customerList = new List<Customer>();

        // Retrieve all rows


        using var cmd = new NpgsqlCommand("select * from customers", _connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var customer = new Customer()
            {
                CustomerId = reader.GetInt32(0),
                CustomerFirstName = reader.GetString(reader.GetOrdinal("firstname")),
                CustomerSecondName = reader.GetString(reader.GetOrdinal("lastname")),
                CustomerEmail = reader.GetString(reader.GetOrdinal("email")),
                CustomerAge = reader.GetInt32(reader.GetOrdinal("age"))
            };

            customerList.Add(customer);
        }

        return customerList;
    }

    public int AddCustomer(Customer customer)
    {
        var sqlScript =
            $"INSERT INTO public.customers(firstname, lastname, email, age) VALUES('{customer.CustomerFirstName}', '{customer.CustomerSecondName}', '{customer.CustomerEmail}', {customer.CustomerAge});";
        using var cmd = new NpgsqlCommand(sqlScript,
            _connection);
        return cmd.ExecuteNonQuery();
    }

    public void UpdateCustomer(Customer customer)
    {
    }

    public int DeleteCustomerById(int id)
    {
        var sqlScript = $"DELETE FROM public.customers WHERE id ={id};";
        using var cmd = new NpgsqlCommand(sqlScript,
            _connection);
        return cmd.ExecuteNonQuery();
    }

    public void GetCustomerById(int id)
    {
    }
}