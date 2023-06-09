namespace Producer.Core.Services.Interface.Base;

public interface IServicePost<TModel> where TModel : class
{
    Task<TModel> PostAsync(TModel data);
}

public interface IServicePost<TRequest, TResponse> where TRequest : class where TResponse : class
{
    public Task<TResponse> PostAsync(TRequest data);
}
