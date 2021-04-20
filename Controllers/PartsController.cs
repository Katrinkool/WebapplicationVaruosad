using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationVaruosad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        // GET: api/<PartsController>
        // /api/parts?page=2&pageSize=50
        // /api/parts?sort=price

        // /api/parts?sort=-price
        // /api/parts?name=KIA
        // /api/parts?SerialNumber=123456

        [HttpGet]
        public List<DTO.PartDTO> Get([FromQuery] QueryParams queryParams)
        {
            List<DTO.PartDTO> rows = new List<DTO.PartDTO>();
            //int count = 0;  -lk kaupa lugemine, asendame LINQ-ga

            using (TextFieldParser parser = new TextFieldParser(@"C:\Kool\Hajusarendused\LE.txt"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters("\t");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] columns = parser.ReadFields();
                    var part = new DTO.PartDTO();
                    part.Serial = columns[0];
                    part.Name = columns[1];
                    part.Price = columns[8];
                    part.PriceVAT = columns[10];
                    part.CarModel = columns[9];

                    int stockCount = 0;
                    int.TryParse(columns[2], out stockCount);
                    part.Stock.Add("Tallinn", stockCount);
                    int.TryParse(columns[3], out stockCount);
                    part.Stock.Add("Tartu", stockCount);
                    int.TryParse(columns[4], out stockCount);
                    part.Stock.Add("Pärnu", stockCount);
                    int.TryParse(columns[5], out stockCount);
                    part.Stock.Add("Kohta-Järve", stockCount);
                    int.TryParse(columns[6], out stockCount);

                    rows.Add(part);

                    /*count++;
                    if (count >= 30)
                        break;*/
                }
            }
            //Lambda expression
            //rows.OrderBy(rida => rida.Price).ToList();  // Lambda expression -sulgude sisse võta rida seest hind ja kasuta sorteerimiseks

            var query = rows.AsQueryable();

            if (queryParams.Sort.ToLower() == "price")
            {
                query = query.OrderBy(row => row.Price);
            }
            else if (queryParams.Sort.ToLower() == "-price")
            {
                query = query.OrderByDescending(row => row.Price);
            }

            if (queryParams.Name.Length > 0)
            {
                query = query.Where(part => part.Name.ToLower().Contains(queryParams.Name.ToLower()));
            }

            if (queryParams.CarModel.Length > 0)
            {
                query = query.Where(part => part.CarModel.Equals(queryParams.CarModel));
            }




            return query.Skip((queryParams.Page - 1 )* queryParams.PageSize).Take(queryParams.PageSize).ToList(); // vastus koos Pagination'ga

        }

        /*// Lambda expression
              var query = rows.AsQueryable();
        if (queryParams.Sort.ToLower() == "price")
        {
            query = query.OrderBy(row => row.Price);
        }
        else if (queryParams.Sort.ToLower() == "-price")
        {
            //rows.OrderByDescending()
        }

        if (queryParams.Name.Length > 0)
        {
            query = query.Where(part => part.Name.Contains(queryParams.Name));
        }

        return query.ToList();*/ // Lambda expression


        //return rows; 

        // GET api/<PartsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PartsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PartsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PartsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
