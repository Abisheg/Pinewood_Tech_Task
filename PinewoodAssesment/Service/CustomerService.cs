
using PinewoodAssessment.Models;
using PinewoodAssessment.Interface;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        // Ensure the BaseAddress is set
        if (_httpClient.BaseAddress == null)
        {
            _httpClient.BaseAddress = new Uri("https://localhost:7276/");
        }
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("api/customers");
    }
    //Not used
    public async Task<Customer> GetCustomerById(int id)
    {
        return await _httpClient.GetFromJsonAsync<Customer>($"api/customers/{id}");
    }

    public async Task AddCustomer(Customer customer)
    {
        await _httpClient.PostAsJsonAsync("api/customers", customer);
    }

    public async Task UpdateCustomer(Customer customer)
    {
        await _httpClient.PutAsJsonAsync($"api/customers", customer);
    }

    public async Task DeleteCustomer(int id)
    {
        await _httpClient.DeleteAsync($"api/customers/{id}");
    }
}
