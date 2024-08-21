var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapPost(
        "/v1/transactions",
        (Request request, Handler handler) 
        => handler.Handle(request))
    .WithSummary("Cria uma nova transação")
    .WithName("Transactions:Create")
    .Produces<Response>();

app.Run();

//Request
public class Request
{
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int Type { get; set; }
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
}

//response

public class Response
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
}

//handler
public class Handler
{
    public Response Handle(Request request)
    {
        return new Response();
    }
}