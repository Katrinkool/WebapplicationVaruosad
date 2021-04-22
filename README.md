# WebApplicationVaruosad
 
This application is designed to read data from the LE.txt file. The data divided into pages. On each page 30 items/lines. The data can be read from the specified port named in the launchsettings.json file as applicationUrl.
Example path: http://localhost:44375/api/parts  

Fo using the search:
- To read the specified page use the query: path+?page="number of the page"  
Example publish find page no 4 with standard ie 30 items in page,   http://localhost:44375/api/parts?page=4

- To read the specified number of items use the query: path+?PageSize="number of items"  
Example publish 40 items in page  http://localhost:44375/api/parts?pageSize=40

- To find the specified items according to the serial number, use the query: path?+serial="serial number"
Example publish items with serial number 123  http://localhost:44375/api/parts?serial=123

- To find parts related to a specific car model, use the query: path?+carModel="car model name "
Example search only items where CarModel “KIA” http://localhost:44375/api/parts?carModel=KIA

- To search for a word or part of a word in the product, use the query: path?+name="word "
Example search only items where name consist word like “turva” http://localhost:44375/api/parts?name=turva

