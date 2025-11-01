namespace GestaoProdutos.Business.Model
{
    public interface IResponse 
    {
        HandlerResult Ok(bool result, string message);
        HandlerResult Invalid(bool result, string message, Exception exception);
    }
}
