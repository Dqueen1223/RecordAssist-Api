namespace Catalyte.SuperHealth.Utilities.HttpResponseExceptions
{
    public interface IHttpResponseException
    {
        public HttpResponseExceptionValue Value { get; set; }
    }
}
