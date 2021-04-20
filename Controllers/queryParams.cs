namespace WebApplicationVaruosad.Controllers
{
    public class QueryParams
    {
        public int Page { get; set; } = 1; //kui midagi ei kirjuta on lk alati 1.ne

        public int PageSize { get; set; } = 30;

        public string Sort { get; set; } = ""; //kui midagi kaasa ei antud siis on tyhi tekst mitte null

        public string Name { get; set; } = "";

        public string SerialNumber { get; set; } = "";

        public string CarModel { get; set; } = "";

    }
}