using System;
using System.Text;

public class Class1
{
    public class TestHelper
    {
        public HttpClient CreateClient()
        {
            return new WebApplicationFactory<Program>().CreateClient();
        }

        public StringContent CreateContent<T>(T entity)
        {
            return new StringContent(JsonConvert.SerializeObject(entity),
                Encoding.UTF8, "application/json");
        }
    }
}
